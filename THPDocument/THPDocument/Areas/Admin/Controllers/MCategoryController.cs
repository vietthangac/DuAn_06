using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;

namespace THPDocument.Areas.Admin.Controllers
{
    public class MCategoryController : MBaseController
    {
        CategoryData ct = new CategoryData();
        DocumentsEntities db = new DocumentsEntities();
        // GET: Admin/MCategory
        public ActionResult Index()
        {
            var model = ct.ListCategory();
            return View(model);
        }

        // GET: Admin/MCategory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/MCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MCategory/Create
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

        // GET: Admin/MCategory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/MCategory/Edit/5
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

        // GET: Admin/MCategory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/MCategory/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                ct.DeleteCategory(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
