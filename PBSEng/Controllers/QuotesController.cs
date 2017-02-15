using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PBSDAL.Entity;
using PBSDAL.PBSManager;

namespace PBSEng.Controllers
{
    [Authorize]
    public class QuotesController : Controller
    {
        private PBSManager mng = new PBSManager();

        public ActionResult Index()
        {            
            return View(mng.AllQuotes());
        }

        public ActionResult AddQuote()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddQuote(Quotes qts)
        {
            var flag = mng.AddQuote(qts);
            if (flag > 0)
            {
                ViewBag.msg = "Quote Added Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.msg = "We are unable to perform this action!";
                return View();
            }
        }

        public ActionResult DeleteQuote(int id)
        {
            var flag = mng.ChangeQuoteStatus(id, false);
            if (flag > 0)
            {
                ViewBag.msg = "Quote Deleted Successfully";
            }
            else
            {
                ViewBag.msg = "We are unable to perform this action!";
            }
            return RedirectToAction("Index");
        }

        public ActionResult EditQuote(int id)
        {
            Quotes qt = mng.AllQuotes().Where(p => p.ID == id).FirstOrDefault();
            return View(qt);
        }

        [HttpPost]
        public ActionResult EditQuote(Quotes qts)
        {
            var flag = mng.UpdateQuote(qts);
            if (flag > 0)
            {
                ViewBag.msg = "Quote Updated Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.msg = "We are unable to perform this action!";
                return View(qts);
            }
        }
    }
}