using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;

namespace THPDocument.Areas.Admin.Controllers
{
    public class DashboashController : MBaseController
    {
        DocumentsEntities db = new DocumentsEntities();
        // GET: Admin/Dashboash
        public ActionResult Index()
        {
            ViewBag.TaiLieu = db.Documents.Count();
            ViewBag.TinTuc = db.News.Count();
            ViewBag.ThanhVien = db.Accounts.Count();
            ViewBag.BaoLoi = db.Reports.Count();
            return View();
        }
    }
}