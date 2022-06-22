using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using WebProje.Models;

namespace WebProje.Areas.Admin.Controllers
{
    public class CourseController : Controller
    {
        // GET: Admin/Course
        public ActionResult Index()
        {
            using (MuratErenNarDatabaseEntities db = new MuratErenNarDatabaseEntities())
            {
                var model = db.Course.ToList();
                return View(model);
            }
        }

        public ActionResult Yeni(Course gelenCourse)
        {
            var model = new Course();
            return View("CourseForm",model);
        }

        public ActionResult Guncelle(int id)
        {
            using (MuratErenNarDatabaseEntities db = new MuratErenNarDatabaseEntities())
            {
                var model = db.Course.Find(id);
                if (model == null)
                {
                    return HttpNotFound("Kurs Bulunamadı");
                }
                return View("CourseForm", model);
            }
        }

        public ActionResult Kaydet(Course gelenCourse)
        {
            //if (!ModelState.IsValid)
            //{
            //    return HttpNotFound("Error");
            //}

            using (MuratErenNarDatabaseEntities db = new MuratErenNarDatabaseEntities())
            {
                if (gelenCourse.Id == 0)       //yeni ürün kayıt
                {
                    if (gelenCourse.imgFile == null)
                    {
                        ViewBag.HataFoto = "Lütfen Resim Yükleyin";
                        return View("CourseForm", gelenCourse);
                    }

                    string fotoAdi = Seo.DosyaAdiDuzenle(gelenCourse.imgFile.FileName);
                    gelenCourse.CourseImage = fotoAdi;
                    db.Course.Add(gelenCourse);
                    gelenCourse.imgFile.SaveAs(Path.Combine(Server.MapPath("~/Content/Core/images"), Path.GetFileName(fotoAdi)));

                    TempData["Course"] = "Kurs Başarılı Bir Şekilde Eklendi";
                }
                else                             //güncelleme                          
                {
                    var guncellenecekVeri = db.Course.Find(gelenCourse.Id);
                    if (gelenCourse.imgFile != null)
                    {
                        string fotoAdi = Seo.DosyaAdiDuzenle(gelenCourse.imgFile.FileName);
                        gelenCourse.CourseImage = fotoAdi;
                        gelenCourse.imgFile.SaveAs(Path.Combine(Server.MapPath("~/Content/Core/images"), Path.GetFileName(fotoAdi)));
                    }
                    db.Entry(guncellenecekVeri).CurrentValues.SetValues(gelenCourse);

                    TempData["Course"] = "Kurs Başarılı Bir Şekilde Eklendi";
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Sil(int id)
        {
            using (MuratErenNarDatabaseEntities db = new MuratErenNarDatabaseEntities())
            {
                var silinecekCourse = db.Course.Find(id);
                if (silinecekCourse == null)
                {
                    return HttpNotFound("Öğrenci Bulunamadı");
                }

                db.Course.Remove(silinecekCourse);
                db.SaveChanges();
                TempData["Course"] = "Öğrenci basarli bir sekilde silindi";
                return RedirectToAction("Index");
            }
        }

    }
}