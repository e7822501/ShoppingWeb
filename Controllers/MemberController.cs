using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using ShoppingWeb.Models.ViewModel;

namespace ShoppingWeb.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public ActionResult Register()
        {
            var jCity = GetCity();
            TempData["CityList"] = "";
            return View("Register");
        }

        [HttpPost]
        public ActionResult RegisterSend(Register model)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login model)
        {
            if (!ValidLogin(model))
            {
                TempData["LoginResult"] = "LoginFailed";
                return View("Index");
            }
            TempData["LoginResult"] = "LoginSuccess";
            Session["account"] = model.Account;
            var foo = JsonConvert.SerializeObject(HttpContext.Request.Cookies["ASP.NET_SessionId"]);
            Debug.WriteLine(foo);
            return View("Index");
        }

        [HttpGet]
        public ActionResult Logout(int id)
        {
            if (id == 1)
            {
                Session.Remove("account");
            }

            return RedirectToAction("Index", "Home");
        }


        [NonAction]
        private string GetCity()
        {
            return ""; 
        }

        [NonAction]
        private bool ValidLogin(Login model)
        {
            var loginModel = new Login()
            {
                Account = "testJeff",
                Password = "1qaz@WSX"
            };
            if (loginModel.Account != model.Account)
            {
                return false;
            }

            if (loginModel.Password != model.Password)
            {
                return false;
            }
            return true;
        }
    }
}