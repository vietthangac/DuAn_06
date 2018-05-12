using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;

namespace THPDocument.Controllers
{
    public class HomeController : Controller
    {
        HomeData hd = new HomeData();
        DocumentsEntities db = new DocumentsEntities();
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var session = (THPDocument.Common.UserLogin)Session[THPDocument.Common.CommonConstants.USER_SESSION];
            if(session!=null)
            {
                ViewBag.Tien = db.Accounts.Where(x => x.ID == session.ID).Select(x => x.AccountPoint).SingleOrDefault();
            }
            ViewBag.Title = "Home";
            var model = hd.ListDocumentPaging(page, pageSize);
            return View(model);
        }
        public ActionResult Details(int id)
        {
            ViewBag.ListComment = db.Comments.Where(x => x.DocumentID == id).ToList();
            var model = db.Documents.Find(id);
            return View(model);
        }
        public ActionResult Info()
        {
            return View();

        }
        public ActionResult Contact()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult CommentGuest(int id)
        {
            var model = db.Comments.Where(x => x.DocumentID == id).ToList();
            return PartialView(model);
        }
        //binh luan
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Comment(Comment collection, int id)
        {
            var session = (THPDocument.Common.UserLogin)Session[THPDocument.Common.CommonConstants.USER_SESSION];
            collection.ComentName = session.ID;
            db.Comments.Add(new Comment
            {
                ComentContent = collection.ComentContent,

                ComentName = collection.ComentName,
                DateComment = DateTime.Now,
                DocumentID = collection.DocumentID
            });
            db.SaveChanges();
            return RedirectToAction("Details","Home", new { id = id});
        }
        [HttpPost]
        public ActionResult Rate(Document collection, int id)
        {
            var getRate = db.Documents.Where(u=>u.DocumentID == id).Select(x => x.Rate).SingleOrDefault();
            collection.Rate = getRate + 1;
            var getDocument = db.Documents.Find(id);
            getDocument.Rate = collection.Rate;
            db.SaveChanges();
            return RedirectToAction("Details", "Home", new { id = id });
        }
        [HttpPost]
        public ActionResult DownloadCode(Account collection,int id)
        {
            var session = (THPDocument.Common.UserLogin)Session[THPDocument.Common.CommonConstants.USER_SESSION];
            var getPoint = db.Accounts.Where(u => u.ID == session.ID).Select(x => x.AccountPoint).SingleOrDefault();
            var getFile = db.Documents.Where(u => u.DocumentID == id).Select(x => x.DocumentFile).SingleOrDefault();
            var getDP = db.Documents.Where(u => u.DocumentID == id).Select(x => x.DocumentPoint).SingleOrDefault();
            try
            {
                if (session.Point < getDP)
                {
                    ViewBag.ErrPoint = "You do not have enough point to download this document!";
                    ModelState.AddModelError("", "You do not have enough point to download this document!");
                }
                else
                {
                    collection.AccountPoint = getPoint - getDP;
                    var getAccount = db.Accounts.Find(session.ID);
                    getAccount.AccountPoint = collection.AccountPoint;
                    db.SaveChanges();
                    return Redirect("/Content/Files/" + getFile);
                }
                return RedirectToAction("KhongDuXu","Home", new { id = id});
            }
            catch
            {
                return View();
            }
        }
        public ActionResult KhongDuXu()
        {
            return View();
        }
    }
}
