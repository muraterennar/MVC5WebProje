using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class HomeController : Controller
    {

        [Route("Anasayfa")]
        public ActionResult Home()
        {
            using (MuratErenNarDatabaseEntities db = new MuratErenNarDatabaseEntities())
            {
                var model = db.Home.Find(1);
                return View(model);
            }
        }

        public ActionResult About()
        {
            using (MuratErenNarDatabaseEntities db = new MuratErenNarDatabaseEntities())
            {
                var model = db.About.Find(1);
                return View(model);
            }
        }

        public ActionResult Courses()
        {
            using (MuratErenNarDatabaseEntities db = new MuratErenNarDatabaseEntities())
            {
                var model = db.Course.ToList();
                return View(model);
            }
        }

        public ActionResult Teachers()
        {
            using (MuratErenNarDatabaseEntities db = new MuratErenNarDatabaseEntities())
            {
                var model = db.Teacher.ToList();
                return View(model);
            }
        }

        public ActionResult Reviews()
        {
            using (MuratErenNarDatabaseEntities db = new MuratErenNarDatabaseEntities())
            {
                var model = db.Comment.ToList();
                return View(model);
            }
        }

        public ActionResult Contact()
        {
            using (MuratErenNarDatabaseEntities db = new MuratErenNarDatabaseEntities())
            {
                var model = db.Contact.Find(1);
                return View(model);
            }
        }
    }
}