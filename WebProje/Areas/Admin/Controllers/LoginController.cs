using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebProje.Models;

namespace WebProje.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Users user)
        {
            if (!ModelState.IsValid)
            {
                return View("index", user);
            }
            using (MuratErenNarDatabaseEntities db = new MuratErenNarDatabaseEntities())
            {
                var model = db.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
                if (model != null)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.Rememberme);
                    return RedirectToAction("/Index", "Panel");
                }
            }

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index");
        }
    }
}