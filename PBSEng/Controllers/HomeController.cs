using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PBSDAL.Entity;
using PBSDAL.PBSManager;
using System.Globalization;
using System.Dynamic;
using PBSEng.Models;

namespace PBSEng.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private PBSManager mng = new PBSManager();
        
        [AllowAnonymous]
        public ActionResult Index()
        {
            ViewData["Portfolio"] = mng.AllPortfolio();
            var pp = mng.AllEvents().Where(p => p._Date > DateTime.Now).OrderByDescending(c => c._Date).ThenBy(c => c._Date.TimeOfDay).ToList();
            ViewData["Events"] = pp;
            ViewData["Testimonial"] = mng.AllTestimonial();
            ViewData["Quotes"] = mng.AllQuotes();
            return View();
        }

        [HttpPost]
        public ActionResult CareerPost(Career crr)
        {
           var flag= mng.AddResume(crr);
           if (flag > 0)
           {
               TempData["msg"] = "Our HR will get back to you very soon";
               return RedirectToAction("Index");
           }
           else
           {
               return Json(false, JsonRequestBehavior.AllowGet);
           }
        }

        [HttpPost]
        public ActionResult ContactForm(ContactForm cntct)
        {
            var flag = mng.AddContact(cntct);
            if (flag > 0)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }        
    }
}