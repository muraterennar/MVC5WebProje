using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProje.Models;
using WebProje.Areas;

namespace WebProje.Areas.Admin.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Admin/Teacher
        public ActionResult Index()
        {
            using (MuratErenNarDatabaseEntities db = new MuratErenNarDatabaseEntities())
            {
                var model = db.Teacher.ToList();
                return View(model);
            }
        }

        public ActionResult TeacherUpdate()
        {
            using (MuratErenNarDatabaseEntities db = new MuratErenNarDatabaseEntities())
            {
                var model = db.Teacher.First();
                return View(model);
            }
        }

        public ActionResult Save(Teacher teacher)
        {
            using (MuratErenNarDatabaseEntities db = new MuratErenNarDatabaseEntities())
            {
                var updateTeacher = db.Teacher.First();
                if (!ModelState.IsValid)
                {
                    return View("TeacherUpdate",teacher);
                }
                if (teacher.TeacherImage != null)
                {
                    teacher.TeacherImage = 
                }
            }
        }

    }
}