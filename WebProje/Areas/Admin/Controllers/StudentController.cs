using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProje.Models;

namespace WebProje.Areas.Admin.Controllers
{
    public class StudentController : Controller
    {
        // GET: Admin/Student
        public ActionResult Index()
        {
            using (MuratErenNarDatabaseEntities db = new MuratErenNarDatabaseEntities())
            {
                var model = db.Users.ToList();
                return View(model);
            }
        }

        public ActionResult Yeni()
        {
            var student = new Users();
            return View("StudentForm", student);

        }

        public ActionResult Guncelle(int id)
        {
            using (MuratErenNarDatabaseEntities db = new MuratErenNarDatabaseEntities())
            {
                var model = db.Users.Find(id);
                if (model == null)
                {
                    return HttpNotFound("Öğretmen Bulunamadı");
                }
                return View("StudentForm", model);
            }
        }

        public ActionResult Kaydet(Users gelenUser)
        {
            //if (!ModelState.IsValid)
            //{
            //    return HttpNotFound("Error");
            //}

            using (MuratErenNarDatabaseEntities db = new MuratErenNarDatabaseEntities())
            {
                if (gelenUser.Id == 0)       //yeni ürün kayıt
                {
                    db.Users.Add(gelenUser);

                    TempData["Student"] = "Öğrenci Başarılı Bir Şekilde Eklendi";
                }
                else                             //güncelleme                          
                {
                    var guncellenecekVeri = db.Users.Find(gelenUser.Id);
                    
                    db.Entry(guncellenecekVeri).CurrentValues.SetValues(gelenUser);

                    TempData["Student"] = "Öğrenci Başarılı Bir Şekilde Eklendi";
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Sil(int id)
        {
            using (MuratErenNarDatabaseEntities db = new MuratErenNarDatabaseEntities())
            {
                var silinecekStudent = db.Users.Find(id);
                if (silinecekStudent == null)
                {
                    return HttpNotFound("Öğrenci Bulunamadı");
                }

                db.Users.Remove(silinecekStudent);
                db.SaveChanges();
                TempData["Student"] = "Öğrenci basarli bir sekilde silindi";
                return RedirectToAction("Index");
            }
        }

    }
}