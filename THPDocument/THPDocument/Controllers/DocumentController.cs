using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using System.IO;

namespace THPDocument.Controllers
{
    public class DocumentController : BaseController
    {
        DocumentsEntities db = new DocumentsEntities();
        DocumentData dd = new DocumentData();
        // GET: Document
        public ActionResult Index()
        {
            return View();
        }

        // GET: Document/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public ActionResult PostSuccess()
        {
            return View();
        }

        // GET: Document/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories.ToList(), "CategoryID", "CategoryName");
            return View();
        }

        // POST: Document/Create
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Document collection)
        {
            try
            {
                // TODO: Add insert logic here
                if(ModelState.IsValid)
                {
                    var session = (THPDocument.Common.UserLogin)Session[THPDocument.Common.CommonConstants.USER_SESSION];
                    //collection.PostBy = id;
                    byte[] imageData = null;
                    HttpPostedFileBase poImgFile = Request.Files["fileim"];
                    HttpPostedFileBase fiFile = Request.Files["filefi"];
                    if (poImgFile != null && poImgFile.ContentLength > 0)
                    {

                        using (var binary = new BinaryReader(poImgFile.InputStream))
                        {
                            imageData = binary.ReadBytes(poImgFile.ContentLength);
                        }
                    }
                    if (fiFile.ContentLength > 0)
                    {
                        string _FileName = Path.GetFileName(fiFile.FileName);
                        string _path = Path.Combine(Server.MapPath("~/Content/Files"), _FileName);
                        fiFile.SaveAs(_path);
                    }
                    collection.DocumentFile = fiFile.FileName;
                    collection.Thumbnail = imageData;
                    collection.Status = false;
                    collection.Rate = 5;
                    collection.DatePost = DateTime.Now;
                    collection.PostBy = session.ID;
                    var res = dd.InsertDocument(collection);
                    int? point = session.Point + 50;
                    dd.AddPoint(point, session.ID);
                    if(res>0)
                    {
                        return RedirectToAction("PostSuccess", "Document");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Upload failed");
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Document/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Document/Edit/5
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

        // GET: Document/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Document/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                dd.DeleteDocument(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
