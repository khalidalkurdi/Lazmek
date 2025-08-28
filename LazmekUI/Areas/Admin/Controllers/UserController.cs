using DataAccess.Db;
using DataAccess.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.ViewModels;
using System;
using Utility;

namespace MyProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        public UserController(IUnitOfWork unitOfWork , RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
           _unitOfWork = unitOfWork;
           _roleManager = roleManager;
           _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult RoleManagment(string userId)
        {           
            var RoleManagmentVM = new RoleManagmentVM
            {                
                user= _unitOfWork.ApplicationUser.Get(u => u.Id == userId),
                RoleLsit= _roleManager.Roles.Select(r => new SelectListItem
                {
                    Text = r.Name,
                    Value = r.Name
                })
            };
             RoleManagmentVM.user.Role = _userManager.GetRolesAsync(_unitOfWork.ApplicationUser.Get(u => u.Id == userId)).GetAwaiter().GetResult().FirstOrDefault();            
            return View(RoleManagmentVM);
        }
        [HttpPost,ActionName(nameof(RoleManagment))]
        public IActionResult RoleManagmentPost(RoleManagmentVM roleManagmentVM)
        {
            
            var userFromDb = _unitOfWork.ApplicationUser.Get(u => u.Id == roleManagmentVM.user.Id);
            var oldRole = _userManager.GetRolesAsync(userFromDb).GetAwaiter().GetResult().FirstOrDefault(); ;

            if (roleManagmentVM.user.Role != oldRole)
            {
                       
                _userManager.RemoveFromRoleAsync(userFromDb, oldRole).GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(userFromDb, roleManagmentVM.user.Role).GetAwaiter().GetResult();
            }            
            _unitOfWork.Save();

            TempData["success"] = "The role Updateed  Successfuly !";
            return RedirectToAction(nameof(Index));
        }

        #region Api Call 
        [HttpGet]
        public IActionResult GetAll()
        {
            List<ApplicationUser> list = _unitOfWork.ApplicationUser.GetAll().ToList();
            
            foreach (var user in list)
            {
                
                user.Role = _userManager.GetRolesAsync(_unitOfWork.ApplicationUser.Get(u => u.Id == user.Id)).GetAwaiter().GetResult().FirstOrDefault();                 
            }
            return Json(new { data = list });
        }
        [HttpPost]
        public IActionResult LockUnLock([FromBody] string id)
        {
            var userFromDb = _unitOfWork.ApplicationUser.Get(u => u.Id == id);
            if(userFromDb == null)
            {
                return Json(new { success = false, message = "Error while lock / unlock user" });
            }
            if (userFromDb.LockoutEnd!=null && userFromDb.LockoutEnd > DateTime.Now)
            {//unlock
                userFromDb.LockoutEnd = DateTime.Now;
            }
            else
            {//lock
                userFromDb.LockoutEnd = DateTime.Now.AddYears(100);
            }
            _unitOfWork.ApplicationUser.Update(userFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Operation Successful" });
        }
        #endregion
    }//end controller
}
