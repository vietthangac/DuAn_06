using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;

namespace THPDocument.Areas.Admin.Controllers
{
    public class MCommentController : MBaseController
    {
        DocumentsEntities db = new DocumentsEntities();
        // GET: Admin/MComment
        public ActionResult Index()
        {
            var model = db.Comments.ToList();
            return View(model);
        }

        // GET: Admin/MComment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/MComment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/MComment/Create
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

        // GET: Admin/MComment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/MComment/Edit/5
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

        // GET: Admin/MComment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/MComment/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var xoa = db.Comments.Find(id);
                db.Comments.Remove(xoa);
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
