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
    public class PortfolioController : Controller
    {
        private PBSManager mng = new PBSManager();

        public ActionResult Index()
        {
            return View(mng.AllPortfolio());
        }

        public ActionResult AddPortfolio()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPortfolio(Portfolio portf)
        {
            int flag = 0;
            var validImageTypes = new string[] { "image/gif", "image/jpeg", "image/jpg", "image/png" };
            if (portf.File != null)
            {
                if (!validImageTypes.Contains(portf.File.ContentType))
                {
                    ModelState.AddModelError("", "Please choose either a GIF, JPG or PNG image.");
                    return View(portf);
                }
                else
                {
                    flag = mng.AddPortfolio(portf);
                }
            }            
            if (flag > 0)
            {
                TempData["UpdateMsg"] = "<i class='fa fa-check-square-o'></i>&nbsp;Portfolio Added Successfully !!! ";
                return RedirectToAction("Index");
            }
            else
            {
                return View(portf);
            }            
        }

        public ActionResult DeletePortfolio(int id)
        {
            var flag = mng.ChangePortfolioStatus(id, false);
            if (flag > 0)
            {
                ViewBag.msg = "Portfolio Deleted Successfully";
            }
            else
            {
                ViewBag.msg = "We are unable to perform this action!";
            }
            return RedirectToAction("Index");
        }

        public ActionResult EditPortfolio(int id)
        {
            Portfolio port = mng.AllPortfolio().Where(p => p.ID == id).FirstOrDefault();
            return View(port);
        }

        [HttpPost]
        public ActionResult EditPortfolio(Portfolio port)
        {
            var validImageTypes = new string[] { "image/gif", "image/jpeg", "image/jpg", "image/png" };
            if (port.File != null)
            {
                if (!validImageTypes.Contains(port.File.ContentType))
                {
                    ModelState.AddModelError("", "Please choose either a GIF, JPG or PNG image.");
                    return View(port);
                }
            }
            else
            {
                var portfolio = mng.AllPortfolio().Where(p => p.ID == port.ID).FirstOrDefault();
                port.Image_Path = portfolio.Image_Path;            
            }
            int flag = flag = mng.UpdatePortfolio(port);
            if (flag > 0)
            {
                TempData["UpdateMsg"] = "<i class='fa fa-check-square-o'></i>&nbsp;Portfolio Updated Successfully !!! ";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["UpdateMsg"] = "<i class='fa fa-check-square-o'></i>&nbsp;Unable to process your request !!! ";
                return View(port);
            }
        }
    }
}