using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PBSDAL.Entity;
using PBSDAL.PBSManager;
using System.Globalization;
using System.Dynamic;

namespace PBSEng.Controllers
{
    public class HomeController : Controller
    {
        private PBSManager mng = new PBSManager();
        
        public ActionResult Index()
        {
            ViewData["Portfolio"] = mng.AllPortfolio();
            ViewData["Events"] = mng.AllEvents();
            ViewData["Testimonial"] = mng.AllTestimonial();
            ViewData["Quotes"] = mng.AllQuotes();
            return View();
        }
        //public ActionResult Team()
        //{
        //    return View();
        //}
    }
}