using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.ViewModels;
using Stripe.Checkout;
using System.Security.Claims;
using Utility;

namespace MyProject.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public ShoppingCartVM ShoppingCartVM { get; set; }
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        public IActionResult Rate(int productId, int rating)
        {
            if (!User.Identity.IsAuthenticated)
            {
                TempData["delete"] = "Please Sign in Lazmek to can rate products";
                return RedirectToPage("/Identity/Account/Register");
            }
            var productFromDb = _unitOfWork.Product.Get(p => p.Id == productId);
            if (productFromDb == null)
            {
                TempData["delete"] = "not found product !";
                return RedirectToAction("Index", "Home");
            }

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (userId != null)
            {
                _unitOfWork.Review.Add(
                    new Review
                    {
                        productId = productId,
                        UserId=userId,
                        Rate = rating
                    }
                );
            }
            _unitOfWork.Save();
            TempData["success"] = "Thank you for your rate, it make websit very reable";

            return RedirectToAction("Details","Home", new { producdId=productId });
        }
    }
}
