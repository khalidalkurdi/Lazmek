
using DataAccess.Repository;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using MyProject.Models;
using Utility;




namespace MyProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =SD.Role_Admin)]
    public class DashboardController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        public DashboardController(IUnitOfWork unitOfWork)
        {
            _unitofwork = unitOfWork;
        }
        public IActionResult Index(int timePeriod)
        {
            if (timePeriod == 0)
            {
                timePeriod = 1;
            }
            DashboardVM dashBoardVM;
            dashBoardVM = new DashboardVM
            {
                timePeriod= timePeriod,

                numberOfUsers = _unitofwork.ApplicationUser.GetAll().Count(),

                numberOfProducts = _unitofwork.Product.GetAll().Count(),

                numberOfOrders = _unitofwork.OrderHeader.GetAll().Count(),

                financialActivities=_unitofwork.OrderHeader.GetAll(o=>o.PaymentStatus==SD.PaymentStatusApproved || o.PaymentStatus==SD.PaymentStatusRejected).Select(o=>new WalletActivities {total=o.OrderTotal,status=o.PaymentStatus }).ToList()
            };
            if (timePeriod == 1)
            {                
                dashBoardVM.growNumberOfUsers = _unitofwork.ApplicationUser.GetAll(u => u.CreateAt == DateOnly.FromDateTime(DateTime.Today)).Count();
                     
                dashBoardVM.growNumberOfProducts = _unitofwork.Product.GetAll(u => u.CreateAt == DateOnly.FromDateTime(DateTime.Today)).Count();
                     
                dashBoardVM.growNumberOfOrders = _unitofwork.OrderHeader.GetAll(u => u.OrderDate.Date == DateTime.Today.Date).Count();
                     
                dashBoardVM.totalOfSales = _unitofwork.OrderHeader.GetAll(u => u.OrderDate == DateTime.Today).Select(o => o.OrderTotal).Sum();
                dashBoardVM.growTotalOfSales = ((_unitofwork.OrderHeader.GetAll(u => u.OrderDate.AddDays(1) == DateTime.Today).Select(o => o.OrderTotal).Sum()
                - _unitofwork.OrderHeader.GetAll(u => u.OrderDate.Date == DateTime.Today).Select(o => o.OrderTotal).Sum()) / 100);               
            }
            else
            {
                dashBoardVM.growNumberOfUsers = _unitofwork.ApplicationUser.GetAll(u => u.CreateAt < DateOnly.FromDateTime(DateTime.Today) && u.CreateAt.AddDays(timePeriod) >= DateOnly.FromDateTime(DateTime.Today)).Count();

                dashBoardVM.growNumberOfProducts = _unitofwork.Product.GetAll(u => u.CreateAt < DateOnly.FromDateTime(DateTime.Today) && u.CreateAt.AddDays(timePeriod) >= DateOnly.FromDateTime(DateTime.Today)).Count();

                dashBoardVM.growNumberOfOrders = _unitofwork.OrderHeader.GetAll(u => u.OrderDate < DateTime.Today && u.OrderDate.AddDays(timePeriod) >= DateTime.Today).Count();

                dashBoardVM.totalOfSales = _unitofwork.OrderHeader.GetAll(u => u.OrderDate < DateTime.Today && u.OrderDate.AddDays(timePeriod) >= DateTime.Today).Select(o => o.OrderTotal).Sum();
                dashBoardVM.growTotalOfSales = ((_unitofwork.OrderHeader.GetAll(u => u.OrderDate < DateTime.Today && u.OrderDate.AddDays(timePeriod) >= DateTime.Today).Select(o => o.OrderTotal).Sum()
                - _unitofwork.OrderHeader.GetAll(u => u.OrderDate < DateTime.Today.AddDays(-timePeriod) && u.OrderDate.AddDays(timePeriod) >= DateTime.Today.AddDays(-timePeriod)).Select(o => o.OrderTotal).Sum()) / 100);
            }
            return View(dashBoardVM);
        }
        

    }//end controller
}
