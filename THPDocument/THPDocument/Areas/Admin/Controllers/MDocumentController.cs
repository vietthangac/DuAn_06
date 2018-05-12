using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;

namespace THPDocument.Areas.Admin.Controllers
{
    public class MDocumentController : MBaseController
    {
        DocumentsEntities db = new DocumentsEntities();
        DocumentData dd = new DocumentData();
        // GET: Admin/MDocument
        public ActionResult Index()
        {
            var model = dd.ListDocument();
            return View(model);
        }

        // GET: Admin/MDocument/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/MDocument/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Document collection)
        {
            try
            {
                // TODO: Add update logic here
                var res = dd.StatusKD(id);
                if(res == true)
                {
                    return RedirectToAction("Index", "MDocument");
                }
                else
                {
                    ModelState.AddModelError("", "An error occurred");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult KiemDuyet()
        {
            var model = dd.ListNotPublist();
            return View(model);
        }
        //do không làm được kiểm duyệt dạng json lên sẽ đem về dạng truyền thống
        [HttpPost]
        public JsonResult StatusKD(int id)
        {
            var result = new DocumentData().StatusKD(id);
            return Json(new
            {
                status = result
            });
        }

        // GET: Admin/MDocument/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/MDocument/Delete/5
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
