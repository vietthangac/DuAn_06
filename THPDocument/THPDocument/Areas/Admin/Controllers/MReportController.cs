using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;

namespace THPDocument.Areas.Admin.Controllers
{
    public class MReportController : MBaseController
    {
        DocumentsEntities db = new DocumentsEntities();
        // GET: Admin/MReport
        public ActionResult Index()
        {
            var model = db.Reports.ToList();
            return View(model);
        }

        // GET: Admin/MReport/Details/5
        public ActionResult Details(int id)
        {
            var model = db.Reports.Find(id);
            return View(model);
        }

        // GET: Admin/MReport/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MReport/Create
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

        // GET: Admin/MReport/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/MReport/Edit/5
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

        // GET: Admin/MReport/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/MReport/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var model = db.Reports.Find(id);
                db.Reports.Remove(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
