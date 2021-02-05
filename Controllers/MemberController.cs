using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Web;
using System.Web.Caching;
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
            if (Session["account"] != null) 
            {
                return Redirect("~/Member/Profile");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
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
            return View("Profile");
        }

        [HttpGet]
        public ActionResult Logout(int id)
        {
            if (id == 1)
            {
                Session.Remove("account");
            }
            return RedirectToAction("Index", "Member");
        }

        [HttpGet]
        public ActionResult Profile() 
        {
            if (Session["account"] == null) 
            {
                RedirectToAction("Index", "Home");
            }
            return View();
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