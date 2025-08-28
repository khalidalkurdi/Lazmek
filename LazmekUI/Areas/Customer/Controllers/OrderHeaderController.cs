using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Models.ViewModels;
using MyProject.Models;
using Stripe;
using Stripe.Checkout;
using Stripe.Climate;
using System.Diagnostics;
using System.Security.Claims;
using Utility;

namespace LazmekUI.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class OrderHeaderController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        [BindProperty]
        private OrderVM orderVM { get; set; }
        public OrderHeaderController(IUnitOfWork unitOfWork)
        {
            _unitofwork = unitOfWork;

        }
        public IActionResult Index()
        {
            var claim = (ClaimsIdentity)User.Identity;
            var userId = claim.FindFirst(ClaimTypes.NameIdentifier).Value;
            var listOrder = _unitofwork.OrderHeader.GetAll(o=>o.UserID==userId,includeProperties:"user").ToList();
            return View(listOrder);
        }
        public IActionResult Details(int orderId)
        {
            orderVM = new OrderVM
            {
                orderHeader = _unitofwork.OrderHeader.Get(x => x.Id == orderId, includeProperties: "user"),
                orderDetail = _unitofwork.OrderDetail.GetAll(x => x.OrderHeaderId == orderId, includeProperties: "product").ToList()
            };            
            return View(orderVM);
        }

    }//end controller
}
