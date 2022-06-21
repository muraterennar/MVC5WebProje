using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProje.Models;
using System.IO;
using System.Text.RegularExpressions;

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

        public ActionResult Yeni()
        {
            Models.Teacher teacher = new Models.Teacher();
            return View("TeacherUpdate", teacher);

        }

        public ActionResult Guncelle(int id)
        {
            using (MuratErenNarDatabaseEntities db = new MuratErenNarDatabaseEntities())
            {
                var model = db.Teacher.Find(id);
                if (model == null)
                {
                    return HttpNotFound("Öğretmen Bulunamadı");
                }
                return View("TeacherUpdate", model);
            }
        }

        public ActionResult Kaydet(Teacher gelenTeacher)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound("Error");
            }

            using (MuratErenNarDatabaseEntities db = new MuratErenNarDatabaseEntities())
            {
                if (gelenTeacher.Id == 0)       //yeni ürün kayıt
                {
                    if (gelenTeacher.imgFile == null)
                    {
                        ViewBag.HataFoto = "Lütfen Resim Yükleyin";
                        return View("TeacherUpdate", gelenTeacher);
                    }

                    string fotoAdi = Seo.DosyaAdiDuzenle(gelenTeacher.imgFile.FileName);
                    gelenTeacher.TeacherImage = fotoAdi;
                    db.Teacher.Add(gelenTeacher);
                    gelenTeacher.imgFile.SaveAs(Path.Combine(Server.MapPath("~/Content/Core/images"), Path.GetFileName(fotoAdi)));

                    TempData["teacher"] = "Öğretmen Başarılı Bir Şekilde Eklendi";
                }
                else                             //güncelleme                          
                {
                    var guncellenecekVeri = db.Teacher.Find(gelenTeacher.Id);
                    if (gelenTeacher.imgFile != null)
                    {
                        string fotoAdi = Seo.DosyaAdiDuzenle(gelenTeacher.imgFile.FileName);
                        gelenTeacher.TeacherImage = fotoAdi;
                        gelenTeacher.imgFile.SaveAs(Path.Combine(Server.MapPath("~/Content/Core/images"), Path.GetFileName(fotoAdi)));
                    }
                    db.Entry(guncellenecekVeri).CurrentValues.SetValues(gelenTeacher);

                    TempData["teacher"] = "Öğretmen Başarılı Bir Şekilde Eklendi";
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Sil(int id)
        {
            using (MuratErenNarDatabaseEntities db = new MuratErenNarDatabaseEntities())
            {
                var silinecekTeacher = db.Teacher.Find(id);
                if (silinecekTeacher == null)
                {
                    return HttpNotFound("Öğretmen Bulunamadı");
                }

                db.Teacher.Remove(silinecekTeacher);
                db.SaveChanges();
                TempData["teacher"] = "Öğretmen basarli bir sekilde silindi";
                return RedirectToAction("Index");
            }
        }

    }

    public class Seo
    {
        public static string DosyaAdiDuzenle(string dosyaAdi)
        {
            string uzantisizDosyaAdi = Path.GetFileNameWithoutExtension(dosyaAdi);
            string uzanti = Path.GetExtension(dosyaAdi);
            return AdresDuzenle(uzantisizDosyaAdi) + uzanti;
        }
        public static string AdresDuzenle(object a)
        {
            string s = a.ToString();

            //s = oncul + id + "-" + s;
            if (string.IsNullOrEmpty(s)) //string yok veya boş ise true döndürür
            {
                return "";
            }

            if (s.Length > 80)
            {
                s = s.Substring(0, 80); //string den belli karakter alır.
            }
            s = s.Replace("ş", "s"); //karakter değişimi için kullanılır
            s = s.Replace("Ş", "S");
            s = s.Replace("ğ", "g");
            s = s.Replace("Ğ", "G");
            s = s.Replace("İ", "I");
            s = s.Replace("ı", "i");
            s = s.Replace("ç", "c");
            s = s.Replace("Ç", "C");
            s = s.Replace("ö", "o");
            s = s.Replace("Ö", "O");
            s = s.Replace("ü", "u");
            s = s.Replace("Ü", "U");
            s = s.Replace("'", "");
            s = s.Replace("\"", "");
            Regex r = new Regex("[^a-zA-Z0-9_-]");
            //if (r.IsMatch(s))
            s = r.Replace(s, "-");
            if (!string.IsNullOrEmpty(s))
                while (s.IndexOf("--") > -1)
                    s = s.Replace("--", "-");
            if (s.StartsWith("-")) s = s.Substring(1);
            if (s.EndsWith("-")) s = s.Substring(0, s.Length - 1);
            return s;
        }
    }
}