using ECommerce.Data_Access_Layer;
using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class UserController : Controller
    {
        private readonly DAL con = new DAL();
        public ActionResult Index()
        {
            var vm = con.GetAllUserDetails();
            return View(vm);
        }
        public ActionResult UserDetails(int UserId)
        {
            var vm = con.GetUserDetails(UserId);
            ViewBag.UserId = UserId;
            return View(vm);
        }
        [HttpPost]
        public ActionResult UserDetails(UserModel user,int UserId)
        {
            bool vm = con.EditUserDetails(user, UserId);
            if (vm)
            {
                return Json(new { success = vm });
            }
            return Json(new { success = false });
        }

        
    }
}