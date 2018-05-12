using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using System.IO;

namespace THPDocument.Areas.Admin.Controllers
{
    public class MNewsController : MBaseController
    {
        NewsData nd = new NewsData();
        DocumentsEntities db = new DocumentsEntities();
        // GET: Admin/MNews
        public ActionResult Index()
        {
            var model = nd.ListNews();
            return View(model);
        }

        // GET: Admin/MNews/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/MNews/Create
        public ActionResult Create()
        {
            ViewBag.TheardID = new SelectList(db.Theards.ToList(), "TheardID", "TheardName");
            return View();
        }

        // POST: Admin/MNews/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(News collection)
        {
            try
            {
                // TODO: Add insert logic here
                var session = (THPDocument.Common.UserLogin)Session[THPDocument.Common.CommonConstants.USER_SESSION];
                byte[] imageData = null;
                HttpPostedFileBase poImgFile = Request.Files["fileim"];
                if (poImgFile != null && poImgFile.ContentLength > 0)
                {

                    using (var binary = new BinaryReader(poImgFile.InputStream))
                    {
                        imageData = binary.ReadBytes(poImgFile.ContentLength);
                    }
                }
                collection.Thumbnail = imageData;
                collection.CreateBy = session.ID;
                collection.CreateDate = DateTime.Now;
                if (ModelState.IsValid)
                {
                    var id = nd.InsertNews(collection);
                    if(id>0)
                    {
                        return RedirectToAction("Index", "MNews");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failures!");
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/MNews/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.TheardID = new SelectList(db.Theards.ToList(), "TheardID", "TheardName");
            var model = db.News.Find(id);
            return View(model);
        }

        // POST: Admin/MNews/Edit/5
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(int id, News collection)
        {
            try
            {
                // TODO: Add update logic here
                var session = (THPDocument.Common.UserLogin)Session[THPDocument.Common.CommonConstants.USER_SESSION];
                byte[] imageData = null;
                HttpPostedFileBase poImgFile = Request.Files["fileim"];
                if (poImgFile != null && poImgFile.ContentLength > 0)
                {

                    using (var binary = new BinaryReader(poImgFile.InputStream))
                    {
                        imageData = binary.ReadBytes(poImgFile.ContentLength);
                    }
                    collection.Thumbnail = imageData;
                    collection.CreateDate = DateTime.Now;
                    var res = nd.UpdateNews(collection);
                    if (id > 0)
                    {
                        return RedirectToAction("Index", "MNews");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Edit  failed!!");
                    }
                }
                else
                {
                    byte[] tana = db.News.Where(x => x.NewsID == id).Select(u => u.Thumbnail).SingleOrDefault();
                    collection.Thumbnail = tana;
                    collection.CreateDate = DateTime.Now;
                    var res = nd.UpdateNews(collection);
                    if (id > 0)
                    {
                        return RedirectToAction("Index", "MNews");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Edit  failed!");
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/MNews/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/MNews/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                nd.DeleteNews(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
