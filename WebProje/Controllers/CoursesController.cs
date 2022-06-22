using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProje.Models;

namespace WebProje.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Course
        public ActionResult WebDeveloper()
        {
            using (MuratErenNarDatabaseEntities context = new MuratErenNarDatabaseEntities())
            {
                var model = context.WebVideoCourses.ToList();
                return View(model);
            }
        }

        public ActionResult BackendDeveloper()
        {
            using (MuratErenNarDatabaseEntities context = new MuratErenNarDatabaseEntities())
            {
                var model = context.BackendVideoCourse.ToList();
                return View(model);
            }
        }

        public ActionResult SocialMediaManagement()
        {
            using (MuratErenNarDatabaseEntities context = new MuratErenNarDatabaseEntities())
            {
                var model = context.SMManagement.ToList();
                return View(model);
            }
        }

        public ActionResult ChemistryAndBiology()
        {
            using (MuratErenNarDatabaseEntities context = new MuratErenNarDatabaseEntities())
            {
                var model = context.ChemistryAndBiology.ToList();
                return View(model);
            }
        }

        public ActionResult English()
        {
            using (MuratErenNarDatabaseEntities context = new MuratErenNarDatabaseEntities())
            {
                var model = context.EnglishCourse.ToList();
                return View(model);
            }
        }
    }
}