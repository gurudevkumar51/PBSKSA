using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PBSDAL.PBSManager;
using System.Web.Mvc;
using PBSDAL.Entity;

namespace PBSEng.Controllers
{
    [Authorize]
    public class TeamController : Controller
    {
        // GET: Team
        private PBSManager mng = new PBSManager();
        public ActionResult Index()
        {
            return View(mng.AllTeamMembers());
        }

        public ActionResult AddTeam()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTeam(Team Tm)
        {
            int flag = 0;
            var validImageTypes = new string[] { "image/gif", "image/jpeg", "image/jpg", "image/png" };
            if (Tm.File != null)
            {
                if (!validImageTypes.Contains(Tm.File.ContentType))
                {
                    ModelState.AddModelError("", "Please choose either a GIF, JPG or PNG image.");
                    return View(Tm);
                }
                else
                {
                    flag = mng.AddTeam(Tm);
                }
            }
            if (flag > 0)
            {
                TempData["UpdateMsg"] = "<i class='fa fa-check-square-o'></i>&nbsp;Team Added Successfully !!! ";
                return RedirectToAction("Index");
            }
            else
            {
                return View(Tm);
            }     
        }

        public ActionResult DeleteTeam(int id)
        {
            var flag = mng.ChangeTeamStatus(id, false);
            if (flag > 0)
            {
                ViewBag.msg = "Team Deleted Successfully";
            }
            else
            {
                ViewBag.msg = "We are unable to perform this action!";
            }
            return RedirectToAction("Index");
        }

        public ActionResult EditTeam(int id)
        {
            Team Tm = mng.AllTeamMembers().Where(p => p.ID == id).FirstOrDefault();
            return View(Tm);
        }

        [HttpPost]
        public ActionResult EditTeam(Team Tm)
        {
            var validImageTypes = new string[] { "image/gif", "image/jpeg", "image/jpg", "image/png" };
            if (Tm.File != null)
            {
                if (!validImageTypes.Contains(Tm.File.ContentType))
                {
                    ModelState.AddModelError("", "Please choose either a GIF, JPG or PNG image.");
                    return View(Tm);
                }
            }
            else
            {
                var team = mng.AllTeamMembers().Where(p => p.ID == Tm.ID).FirstOrDefault();
                Tm.ImagePath = team.ImagePath;
            }
            int flag = flag = mng.UpdateTeam(Tm);
            if (flag > 0)
            {
                TempData["UpdateMsg"] = "<i class='fa fa-check-square-o'></i>&nbsp;Team Updated Successfully !!! ";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["UpdateMsg"] = "<i class='fa fa-check-square-o'></i>&nbsp;Unable to process your request !!! ";
                return View(Tm);
            }
        }
    }
}