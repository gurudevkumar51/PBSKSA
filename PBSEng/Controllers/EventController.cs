using PBSDAL.Entity;
using PBSDAL.PBSManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PBSEng.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private PBSManager mng = new PBSManager();        
        
        public ActionResult Index()
        {
            return View(mng.AllEvents());
        }

        public ActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEvent(Event evnt)
        {
            var flag = mng.AddEvent(evnt);
            if (flag > 0)
            {
                ViewBag.msg = "Event created Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.msg = "We are unable to perform this action!";
                return View();
            }
        }

        public ActionResult DeleteEvent(int id)
        {
            var flag = mng.ChangeEventStatus(id, false);
            if (flag > 0)
            {
                ViewBag.msg = "Event Deleted Successfully";
            }
            else
            {
                ViewBag.msg = "We are unable to perform this action!";
            }
            return RedirectToAction("Index");
        }

        public ActionResult EditEvent(int id)
        {
            Event evnt = mng.AllEvents().Where(p => p.ID == id).FirstOrDefault();
            return View(evnt);
        }

        [HttpPost]
        public ActionResult EditEvent(Event evnt)
        {
            var flag = mng.UpdateEvent(evnt);
            if (flag > 0)
            {
                ViewBag.msg = "Event Updated Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.msg = "We are unable to perform this action!";
                return View(evnt);
            }
        }

        public ActionResult Team()
        {
            return View();
        }
    }
}