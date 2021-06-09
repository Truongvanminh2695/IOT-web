using AutomaticWatering.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutomaticWatering.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["UserName"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Account account)
        {
            if (account.UserName != null && account.Password != null)
            {
                if (account.UserName.Equals("hethongnhung") && account.Password.Equals("nhom1"))
                {
                    Session["UserName"] = account.UserName;
                    return RedirectToAction("IndexAsync", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError("errLogin", "Thông tin đăng nhập không chính xác!");
                }
            }
            return View();
        }
    }
}