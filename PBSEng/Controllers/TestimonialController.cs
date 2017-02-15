using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PBSDAL.Entity;
using PBSDAL.PBSManager;
using System.IO;

namespace PBSEng.Controllers
{
    [Authorize]
    public class TestimonialController : Controller
    {
        private PBSManager mng = new PBSManager();

        public ActionResult Index()
        {
            return View(mng.AllTestimonial());
        }

        public ActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTestimonial(Testimonial tstmnl)
        {
            int flag = 0;
            var validImageTypes = new string[] { "image/gif", "image/jpeg", "image/jpg", "image/png" };
            if (tstmnl.File != null)
            {
                if (!validImageTypes.Contains(tstmnl.File.ContentType))
                {
                    ModelState.AddModelError("", "Please choose either a GIF, JPG or PNG image.");
                    return View(tstmnl);
                }
                else
                {
                    flag = mng.AddTestimonial(tstmnl);
                }
            }
            if (flag > 0)
            {
                TempData["UpdateMsg"] = "<i class='fa fa-check-square-o'></i>&nbsp;Testimonial Added Successfully !!! ";
                return RedirectToAction("Index");
            }
            else
            {
                return View(tstmnl);
            }     
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var flag = mng.ChangeTestimonialStatus(id, false);
            if (flag > 0)
            {
                ViewBag.msg = "Testimonial Deleted Successfully";
            }
            else
            {
                ViewBag.msg = "We are unable to perform this action!";
            }
            return RedirectToAction("Index");
        }

        public ActionResult EditTestimonial(int id)
        {
            Testimonial tstmnl = mng.AllTestimonial().Where(p => p.ID == id).FirstOrDefault();
            return View(tstmnl);
        }

        [HttpPost]
        public ActionResult EditTestimonial(Testimonial tstmnl)
        {
            var validImageTypes = new string[] { "image/gif", "image/jpeg", "image/jpg", "image/png" };
            if (tstmnl.File != null)
            {
                if (!validImageTypes.Contains(tstmnl.File.ContentType))
                {
                    ModelState.AddModelError("", "Please choose either a GIF, JPG or PNG image.");
                    return View(tstmnl);
                }
            }
            else
            {
                var testimonial = mng.AllTestimonial().Where(p => p.ID == tstmnl.ID).FirstOrDefault();
                tstmnl.Image_Path = testimonial.Image_Path;
            }
            int flag = flag = mng.UpdateTestimonial(tstmnl);
            if (flag > 0)
            {
                TempData["UpdateMsg"] = "<i class='fa fa-check-square-o'></i>&nbsp;Testimonial Updated Successfully !!! ";
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Error", "Login");
            }            
        }
    }
}