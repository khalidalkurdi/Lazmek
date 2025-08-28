using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.ViewModels;
using MyProject.Models;
using System.Diagnostics;
using System.Security.Claims;
using Utility;
namespace MyProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Welcome(bool gust=false)
        {
            if(gust)
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Base(bool gust=false, bool asUser= false)
        {
            // redirect the user based on his role
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole(SD.Role_Admin) && !asUser)
                {
                    return RedirectToAction("Index", "Dashboard", new {Area="Admin"});
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }
            }                        
            return RedirectToAction(nameof(Welcome));                                           
        }
        public IActionResult Index(string? search,string? category)
        {
            HomeIndexVM homeIndexVM = new HomeIndexVM
            {
                categories=_unitOfWork.Category.GetAll().Select(c => c.Name).ToList(),
            };     
            
            if (!string.IsNullOrEmpty(category))
            {
                homeIndexVM.categorytSelected = category;
                homeIndexVM.products = _unitOfWork.Product.GetAll(p=>p.Category.Name==category, includeProperties: "Category,ProductImages,Reviews").ToList();              
                return View(homeIndexVM);
            }
            if (!string.IsNullOrEmpty(search))
            {
                homeIndexVM.products = _unitOfWork.Product.GetAll(p=>EF.Functions.Contains( p.Title,search)|| EF.Functions.Contains(p.Description, search), includeProperties: "Category,ProductImages,Reviews").ToList();
                if (homeIndexVM.products.Any())
                {                   
                    return View(homeIndexVM);
                }
                TempData["delete"] = "Not Found Any Matche";
            }
            homeIndexVM.products = _unitOfWork.Product.GetAll(includeProperties: "Category,ProductImages,Reviews").ToList();
            return View(homeIndexVM);
        }
        [HttpGet]
        public IActionResult Details(int producdId)
        {
            var ShoppingCart = new ShoppingCart
            {
                product=_unitOfWork.Product.Get(p=>p.Id==producdId, includeProperties: "Category,ProductImages,Reviews"),
                ProductId=producdId

            };
            return View(ShoppingCart);
        }
        [Authorize]
        [HttpPost]
        [ActionName(nameof(Details))]
        public IActionResult DetailsPost(ShoppingCart cart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            cart.UserID= userId;

            var cartFromDb = _unitOfWork.ShoppingCart.Get(sh=>sh.ProductId==cart.ProductId && sh.UserID==userId);
            if (cartFromDb != null)
            {
                cartFromDb.Count += cart.Count;
                _unitOfWork.ShoppingCart.Update(cartFromDb);
                _unitOfWork.Save();
            }
            else
            {
                _unitOfWork.ShoppingCart.Add(cart);
                _unitOfWork.Save();
                var cartCount = _unitOfWork.ShoppingCart.GetAll(u => u.UserID == userId).Count();
                HttpContext.Session.SetInt32(SD.SessionShoppingCart, cartCount);
            }

            TempData["update"] = "Cart updated successfuly!";
            return RedirectToAction("Index");
        }
        
    }
}
