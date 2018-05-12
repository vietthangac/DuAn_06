using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;

namespace THPDocument.Controllers
{
    public class RegisterController : Controller
    {
        DocumentsEntities db = new DocumentsEntities();
        AccountData ad = new AccountData();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Account collection)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    collection.RoleID = 1;
                    collection.AccountRate = 0;
                    collection.AccountPoint = 0;
                    int id = ad.InsertAccount(collection);
                    if (id > 0)
                    {
                        return RedirectToAction("RegisterSuccess", "Register");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Register failed!");
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult RegisterSuccess()
        {
            return View();
        }
    }
}
