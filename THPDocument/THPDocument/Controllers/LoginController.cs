using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THPDocument.Models;
using Data;
using THPDocument.Common;

namespace THPDocument.Controllers
{
    public class LoginController : Controller
    {
        AccountData ad = new AccountData();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginModel lg)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    var res = ad.checkLogin(lg.Username, lg.Password);
                    if (res == true)
                    {
                        var user = ad.GetByID(lg.Username);
                        var userSession = new UserLogin();
                        userSession.Username = user.Username;
                        userSession.ID = user.ID;
                        userSession.FullName = user.FullName;
                        userSession.Point = user.AccountPoint;
                        Session.Add(CommonConstants.USER_SESSION, userSession);
                        return RedirectToAction("/", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Login failed!");
                    }
                }
                return View(lg);
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/");
        }
    }
}