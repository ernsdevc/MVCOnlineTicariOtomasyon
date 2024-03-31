using MVCOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        Context context = new Context();

        // GET: Cari
        public ActionResult Index()
        {
            var values = context.Carilers.Where(x => x.Durum == true).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CariEkle(Cariler cari)
        {
            cari.Durum = true;
            context.Carilers.Add(cari);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var values = context.Carilers.Find(id);
            values.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariGetir(int id)
        {
            var values = context.Carilers.Find(id);
            return View("CariGetir", values);
        }

        public ActionResult CariGuncelle(Cariler cari)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }
            var values = context.Carilers.Find(cari.CariID);
            values.CariAd = cari.CariAd;
            values.CariSoyad = cari.CariSoyad;
            values.Sehir = cari.Sehir;
            values.Mail = cari.Mail;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSatis(int id)
        {
            var values = context.SatisHarekets.Where(x => x.CariID == id).ToList();
            var cari = context.Carilers.Where(x => x.CariID == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.v = cari;
            return View(values);
        }
    }
}