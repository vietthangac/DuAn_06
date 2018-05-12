using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;

namespace THPDocument.Controllers
{
    public class NewsController : Controller
    {
        DocumentsEntities db = new DocumentsEntities();
        // GET: News
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult NewsHome()
        {
            var model = new NewsData().ListNewsHome();
            return PartialView(model);
        }

        [ChildActionOnly]
        public PartialViewResult YeuThich(int page = 1, int pageSize = 5)
        {
            var model = new HomeData().ListDocumentYeuThich(page,pageSize);
            return PartialView(model);
        }

        // GET: News/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.ListTheard = db.Theards.ToList();
            var model = db.News.Find(id);
            return View(model);
        }

        // GET: News/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: News/Create
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

        // GET: News/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: News/Edit/5
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

        // GET: News/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: News/Delete/5
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
