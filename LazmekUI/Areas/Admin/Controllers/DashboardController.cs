
using DataAccess.Repository;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {            
            return View();
        }
        

    }//end controller
}
