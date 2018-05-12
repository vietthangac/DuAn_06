using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Data.Manager;

namespace THPDocument.Areas.Admin.Controllers
{
    public class MAccountController : MBaseController
    {
        DocumentsEntities db = new DocumentsEntities();
        ManagerAccountData md = new ManagerAccountData();
        // GET: Admin/MAccount
        public ActionResult Index()
        {
            var model = md.ListAccount();
            return View(model);
        }

        // GET: Admin/MAccount/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/MAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MAccount/Create
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

        // GET: Admin/MAccount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/MAccount/Edit/5
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

        // GET: Admin/MAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/MAccount/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
