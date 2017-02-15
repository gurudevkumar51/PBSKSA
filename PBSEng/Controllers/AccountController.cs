using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using PBSEng.Models;
using PBSDAL.PBSManager;

namespace PBSEng.Controllers
{
    public class AccountController : Controller
    {
        private PBSManager mng = new PBSManager();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login lgn, string ReturnUrl ="")
        {            
            var user= mng.AllUsers().Where(p => p.Username == lgn.Username && p.Password == lgn.Password).FirstOrDefault();
            if (user != null)
            {
                FormsAuthentication.SetAuthCookie(user.Username, lgn.RememberMe);
                if (Url.IsLocalUrl(ReturnUrl))
                {
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Event");
                }
            }
            ModelState.Remove("Password"); 
            return View();
        }

        [Authorize]
        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}