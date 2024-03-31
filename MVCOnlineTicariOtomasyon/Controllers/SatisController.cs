using MVCOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        Context context = new Context();

        // GET: Satis
        public ActionResult Index()
        {
            var values = context.SatisHarekets.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult SatisYap()
        {
            List<SelectListItem> value1 = (from x in context.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()
                                           }).ToList();
            ViewBag.v1 = value1;

            List<SelectListItem> value2 = (from x in context.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariID.ToString()
                                           }).ToList();
            ViewBag.v2 = value2;

            List<SelectListItem> value3 = (from x in context.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            ViewBag.v3 = value3;
            return View();
        }

        [HttpPost]
        public ActionResult SatisYap(SatisHareket satisHareket)
        {
            satisHareket.Tarih = DateTime.Now.Date;
            context.SatisHarekets.Add(satisHareket);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> value1 = (from x in context.Uruns.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.UrunAd,
                                               Value = x.UrunID.ToString()
                                           }).ToList();
            ViewBag.v1 = value1;

            List<SelectListItem> value2 = (from x in context.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariID.ToString()
                                           }).ToList();
            ViewBag.v2 = value2;

            List<SelectListItem> value3 = (from x in context.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            ViewBag.v3 = value3;
            var values = context.SatisHarekets.Find(id);
            return View(values);
        }

        public ActionResult SatisGuncelle(SatisHareket satisHareket)
        {
            var values = context.SatisHarekets.Find(satisHareket.SatisID);
            values.UrunID = satisHareket.UrunID;
            values.CariID = satisHareket.CariID;
            values.PersonelID = satisHareket.PersonelID;
            values.Adet = satisHareket.Adet;
            values.Fiyat = satisHareket.Fiyat;
            values.ToplamTutar = satisHareket.ToplamTutar;
            values.Tarih = satisHareket.Tarih;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisDetay(int id)
        {
            var values = context.SatisHarekets.Where(x => x.SatisID == id).ToList();
            return View(values);
        }
    }
}