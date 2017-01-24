using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Projekt.NETWeb.Models;
using System.Web.Mvc;

namespace Projekt.NETWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult Wall()
        {
            var ViewModel = new WallViewModel
            {
                TotalCount = 0
            };
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.IsAdmin = "No";

                if (isAdminUser())
                {
                    ViewBag.IsAdmin = "Yes";
                }
                return View(ViewModel);
            }
            return View(ViewModel);
        }
        public bool isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                    return true;
                else
                    return false;
            }
            return false;
        }

        public ActionResult WhatIsPrimous()
        {
            return View();
        }
    }
}