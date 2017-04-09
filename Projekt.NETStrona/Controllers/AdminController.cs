using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Projekt.NETStrona.Models;
using System.Web.Mvc;
namespace Projekt.NEStrona.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (!IsAdminUser())
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        public bool IsAdminUser()
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
