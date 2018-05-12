using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;

namespace THPDocument.Areas.Admin.Controllers
{
    public class MTheardController : MBaseController
    {
        DocumentsEntities db = new DocumentsEntities();
        TheardData td = new TheardData();
        // GET: Admin/MTheard
        public ActionResult Index()
        {
            var model = td.ListTheard();
            return View(model);
        }

        // GET: Admin/MTheard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/MTheard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MTheard/Create
        [HttpPost]
        public ActionResult Create(Theard collection)
        {
            try
            {
                // TODO: Add insert logic here
                var res = td.InsertTheard(collection);
                if(res)
                {
                    return RedirectToAction("Index", "MTheard");
                }
                else
                {
                    ModelState.AddModelError("", "An error occurred!");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/MTheard/Edit/5
        public ActionResult Edit(int id)
        {
            var model = db.Theards.Find(id);
            return View(model);
        }

        // POST: Admin/MTheard/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Theard collection)
        {
            try
            {
                // TODO: Add update logic here
                var res = td.UpdateTheard(collection);
                if (res)
                {
                    return RedirectToAction("Index", "MTheard");
                }
                else
                {
                    ModelState.AddModelError("", "An error occurred!");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/MTheard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/MTheard/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                td.DeleteTheard(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
