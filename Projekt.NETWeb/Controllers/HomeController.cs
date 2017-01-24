using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Projekt.NETWeb.Models;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Projekt.NETWeb.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
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

        public ActionResult WhatIsPrymous()
        {
            return View();
        }
        public ActionResult Wall()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.IsAdmin = "No";

                if (isAdminUser())
                {
                    ViewBag.IsAdmin = "Yes";
                }
            }
            return View();
        }
        public PartialViewResult CreatePost(Post post)
        {
            return PartialView("_CreatePostPartial", new Post());
        }
        // POST: Home/CreatePostPost
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreatePostPost([Bind(Include = "PostContent")] Post post)
        {

            post.DateCreated = System.DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                await db.SaveChangesAsync();
                return RedirectToAction("Wall");
            }

            return View("Wall", post);
        }
        public PartialViewResult ViewPosts()
        {
            return PartialView("_ViewPostsPartial", db.Posts);
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
    }
}