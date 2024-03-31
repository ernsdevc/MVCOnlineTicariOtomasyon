using MVCOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        Context context = new Context();

        // GET: Urun
        public ActionResult Index(string ara)
        {
            var values = context.Uruns.Where(x => x.Durum == true);
            if (!String.IsNullOrEmpty(ara))
            {
                values = values.Where(x => x.UrunAd.Contains(ara));
            }
            return View(values.ToList());
        }

        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> value =(from x in context.Kategoris.ToList() select new SelectListItem
            {
                Text = x.KategoriAd,
                Value = x.KategoriID.ToString()
            }).ToList();
            ViewBag.v = value;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Urun urun)
        {
            context.Uruns.Add(urun);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(int id)
        {
            var values = context.Uruns.Find(id);
            values.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> value = (from x in context.Kategoris.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.KategoriAd,
                                              Value = x.KategoriID.ToString()
                                          }).ToList();
            ViewBag.v = value;
            var values = context.Uruns.Find(id);
            return View("UrunGetir", values);
        }

        public ActionResult UrunGuncelle(Urun urun)
        {
            var values = context.Uruns.Find(urun.UrunID);
            values.AlisFiyat = urun.AlisFiyat;
            values.SatisFiyat = urun.SatisFiyat;
            values.Durum = urun.Durum;
            values.Stok = urun.Stok;
            values.KategoriID = urun.KategoriID;
            values.Marka = urun.Marka;
            values.Resim = urun.Resim;
            values.UrunAd = urun.UrunAd;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunListesi()
        {
            var values = context.Uruns.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult SatisYap(int id)
        {
            ViewBag.v1 = id;
            ViewBag.v2 = context.Uruns.Find(id).UrunAd;
            List<SelectListItem> value3 = (from x in context.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariID.ToString()
                                           }).ToList();
            ViewBag.v3 = value3;

            List<SelectListItem> value4 = (from x in context.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.PersonelAd + " " + x.PersonelSoyad,
                                               Value = x.PersonelID.ToString()
                                           }).ToList();
            ViewBag.v4 = value4;
            ViewBag.v5 = context.Uruns.Find(id).SatisFiyat.ToString();
            return View();
        }

        [HttpPost]
        public ActionResult SatisYap(SatisHareket satisHareket)
        {
            satisHareket.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            context.SatisHarekets.Add(satisHareket);
            context.SaveChanges();
            return RedirectToAction("Index", "Satis");
        }
    }
}