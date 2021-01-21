using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using ShoppingWeb.Models.ViewModel;

namespace ShoppingWeb.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index()
        {
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
            return View("Done");
        }

        [HttpPost]
        public ActionResult Login(Login model)
        {
            if (!ValidLogin(model))
            {
                TempData["LoginResult"] = "LoginFailed";
                return View("Index");
            }

            TempData["LogindResult"] = "LoginSuccess";
            return View("Index");
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