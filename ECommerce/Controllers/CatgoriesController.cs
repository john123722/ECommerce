using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerce.Data_Access_Layer;
using ECommerce.Models;
namespace ECommerce.Controllers
{
    [Authorize]
    public class CatgoriesController : Controller
    {
        private readonly DAL con = new DAL();
        // GET: Catgories
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewCategories()
        {
            var vm = con.GetCategories();
            return View(vm);
        }
        [HttpPost]
        public ActionResult AddCategories(string Cat_name)
        {
            bool res = con.AddCategories(Cat_name);
            return Json(new { success = res });
        }

        [HttpPost]
        public ActionResult EditCategories(string CatName, int CatId)
        {
            bool res = con.EditCategories(CatName, CatId);
            return Json(new { success = res });
        }

        [HttpPost]
        public ActionResult DeleteCategories(int CatId)
        {
            bool res = con.DeleteCategories(CatId);
            return Json(new { success = res });
        }
    }
}