using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using System.IO;
using THPDocument.Models;

namespace THPDocument.Controllers
{
    public class ProfileController : Controller
    {
        DocumentsEntities db = new DocumentsEntities();
        DocumentData dd = new DocumentData();
        // GET: Profile
        public ActionResult Index()
        {
            var model = new AccountData().ListAccount();
            return View(model);
        }

        // GET: Profile/Details/5
        public ActionResult Details(int id)
        {
            var model = db.Accounts.Find(id);
            ViewBag.ListDocumentByUser = dd.ListDocumentByUser(id);
            return View(model);
        }
        public ActionResult ChangePassword(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(int id, ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {

                var mk = db.Accounts.Find(id);
                if (mk.Password == model.OldPassword)
                {
                    mk.Password = model.PasswordNew;
                    db.SaveChanges();
                    ViewBag.Done = "Change password successfully!";
                }
                else
                {
                    ModelState.AddModelError("", "Old password is wrong!");
                }
                return View(model);
            }
            return View();
        }

        // GET: Profile/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Profile/Edit/5
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

        public ActionResult EditDocument(int id)
        {
            ViewBag.CategoryID = new SelectList(db.Categories.ToList(), "CategoryID", "CategoryName");
            var model = db.Documents.Find(id);
            return View(model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditDocument(int id, Document collection)
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
                    var res = dd.UpdateDocument(collection);
                    if (res)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Failed!");
                    }
                }
                else
                {
                    byte[] tana = db.Documents.Where(x => x.DocumentID == id).Select(u => u.Thumbnail).SingleOrDefault();
                    collection.Thumbnail = tana;
                    var res = dd.UpdateDocument(collection);
                    if (res)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Change failed!");
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // GET: Profile/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Profile/Delete/5
        [HttpDelete]
        public ActionResult Delete(int id, FormCollection collection)
        {
            //Console.WriteLine("zxczxczxc");
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
