using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Projekt.NETStrona;
using Projekt.NETStrona.Models;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Projekt.NETWeb.Controllers
{
    public class HomeController : Controller
    {
        ApplicationUserManager _userManager = null;
        ApplicationDbContext db = new ApplicationDbContext();
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
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

                if (IsAdminUser())
                {
                    ViewBag.IsAdmin = "Yes";
                }
            }
            return View();
        }
        public PartialViewResult CreatePost()
        {
            return PartialView("_CreatePostPartial", new Post());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreatePost([Bind(Include = "PostContent")] Post post)
        {
            if (User.Identity.IsAuthenticated)
            {
                post.UserName = User.Identity.GetUserName();
            }
            else
            {
                post.UserName = "Anonym";
            }
            post.Edited = false;
            post.DateEdited = System.DateTime.Now;
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

        public async Task<ActionResult> FullPostView(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = await db.Posts.FindAsync(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        public async Task<ActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = await db.Posts.FindAsync(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditPost([Bind(Include = "PostId, UserName, DateCreated, PostContent")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.UserName = post.UserName;
                post.Edited = true;
                post.DateEdited = System.DateTime.Now;
                post.DateCreated = post.DateCreated;
                db.Entry(post).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Wall");
            }
            return View(post);
        }

        public async Task<ActionResult> DeletePostConfirm(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = await db.Posts.FindAsync(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeletePost(int id)
        {
            Post post = await db.Posts.FindAsync(id);
            db.Posts.Remove(post);
            await db.SaveChangesAsync();
            return RedirectToAction("Wall");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public bool IsAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                try
                {
                    if (s[0].ToString() == "Admin")
                        return true;
                    else
                        return false;
                }
                catch (System.Exception e)
                { return false; }
            }
            return false;
        }
    }
}