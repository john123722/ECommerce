using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ECommerce.Data_Access_Layer;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly DAL con = new DAL();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string UserName,string PassWord)
        {
            bool res = VerifyUser(UserName, PassWord);
            return Json(new { success = res });

        }

        public void SellerValidation(int vm,int userId,int userType)
        {
            HttpCookie sellerCookie = new HttpCookie("IsSeller");
            HttpCookie userCookie = new HttpCookie("User");
            HttpCookie userTypeCookie = new HttpCookie("UserType");
            sellerCookie.Value = vm == 1 ? "true" : "false";
            userCookie.Value = userId.ToString();
            userTypeCookie.Value = userType == 1 ? "true" : "false";
            sellerCookie.Expires = DateTime.Now.AddMinutes(10);
            userCookie.Expires = DateTime.Now.AddMinutes(10);
            userTypeCookie.Expires = DateTime.Now.AddMinutes(10);
            Response.Cookies.Add(sellerCookie);
            Response.Cookies.Add(userCookie);
            Response.Cookies.Add(userTypeCookie);
            HttpCookie loginCookie = new HttpCookie("Login")
            {
                Value = "True",
                Expires = DateTime.Now.AddMinutes(10)
            };
            Response.Cookies.Add(loginCookie);
        }

        public bool VerifyUser(string userName, string passWord)
        {
            var usr = userName;
            var pw = passWord;
            var vm = con.AuthorizeUser();
            foreach (var item in vm)
            {
                if (item.UserName==usr && item.Password == pw)
                {
                    var seller = item.Seller;
                    var userId = item.UserId;
                    var userType = item.UserType;
                    SellerValidation(seller,userId,userType);
                    SetUser(usr);
                    FormsAuthentication.SetAuthCookie(item.UserName, false);
                    return true;
                }
            }
            return false;
        }
        public void SetUser(string usr)
        {
            HttpCookie UserNameCookie = new HttpCookie("UserName");
            UserNameCookie.Value = usr;
            UserNameCookie.Expires = DateTime.Now.AddMinutes(10);
            Response.Cookies.Add(UserNameCookie);
        }

        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(UserModel user)
        {
            if(user.Seller == 1)
            {
                user.UserType = 2;
            }
            else
            {
                user.UserType = 3;
            }
            if (con.AddUser(user))
            {
                return RedirectToAction("Login", "Account");
            }
            return RedirectToAction("SignUp", "Account");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            RemoveCookies();
            return RedirectToAction("Demo", "Account");
        }
        public void RemoveCookies()
        {
            HttpCookie loginCookie = new HttpCookie("Login");
            loginCookie.Value = "False";
            loginCookie.Expires = DateTime.Now.AddMinutes(-4);
            Response.Cookies.Add(loginCookie);
        }
        public ActionResult Demo()
        {
            var vm = con.GetItems();
            SetCookies();
            return View(vm);
        }
        public void SetCookies()
        {
            HttpCookie loginCookie = new HttpCookie("Login");
            loginCookie.Value = "False";
            loginCookie.Expires = DateTime.Now.AddMinutes(10);
            Response.Cookies.Add(loginCookie);
        }

        public ActionResult UserDetails()
        {
            int userId = (int)Convert.ToInt64(Request.Cookies["User"].Value);
            var vm = con.GetUserDetails(userId);
            return View(vm);
        }
        [HttpPost]
        public ActionResult UserDetails(UserModel user)
        {
            int userId = (int)Convert.ToInt64(Request.Cookies["User"].Value);
            bool vm = con.EditUserDetails(user, userId);
            if (vm)
            {
                return Json(new { success = vm });
            }
            return Json(new { success = false });
        }
    }
}