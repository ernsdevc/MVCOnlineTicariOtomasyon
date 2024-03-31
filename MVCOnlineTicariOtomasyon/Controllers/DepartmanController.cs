using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Siniflar;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        Context context = new Context();

        // GET: Departman
        [Authorize]
        public ActionResult Index()
        {
            var values = context.Departmans.Where(X => X.Durum == true).ToList();
            return View(values);
        }

        [Authorize(Roles = "A")]
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult DepartmanEkle(Departman departman)
        {
            departman.Durum = true;
            context.Departmans.Add(departman);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult DepartmanSil(int id)
        {
            var values = context.Departmans.Find(id);
            values.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult DepartmanGetir(int id)
        {
            var values = context.Departmans.Find(id);
            return View("DepartmanGetir", values);
        }

        [Authorize]
        public ActionResult DepartmanGuncelle(Departman departman)
        {
            var values = context.Departmans.Find(departman.DepartmanID);
            values.DepartmanAd = departman.DepartmanAd;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult DepartmanDetay(int id)
        {
            var values = context.Personels.Where(x => x.DepartmanID == id).ToList();
            var departman = context.Departmans.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.v = departman;
            return View(values);
        }

        [Authorize]
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var values = context.SatisHarekets.Where(x => x.PersonelID == id).ToList();
            var personel = context.Personels.Where(x => x.PersonelID == id).Select(y=>y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.v = personel;
            return View(values);
        }
    }
}