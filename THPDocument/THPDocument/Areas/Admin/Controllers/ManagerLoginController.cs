using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THPDocument.Areas.Admin.Models;
using Data.Manager;
using THPDocument.Common;
using Data;
namespace THPDocument.Areas.Admin.Controllers
{
    public class ManagerLoginController : Controller
    {
        ManagerLoginData mlg = new ManagerLoginData();
        DocumentsEntities db = new DocumentsEntities();
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(ManagerLoginModel lg)
        {
            var res = mlg.checkAdminLogin(lg.Username, lg.Password);

            if(res)
            {
                AccountData ad = new AccountData();
                var user = ad.GetByID(lg.Username);
                var userSession = new UserLogin();
                userSession.Username = user.Username;
                userSession.ID = user.ID;
                userSession.FullName = user.FullName;
                Session.Add(CommonConstants.USER_SESSION, userSession);
                return RedirectToAction("Index", "Dashboash");
            }
            else
            {
                ModelState.AddModelError("", "Login failed!");
            }
            return View();
        }
        // GET: Admin/Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Login/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return Redirect("/Admin/ManagerLogin");
        }
    }
}
