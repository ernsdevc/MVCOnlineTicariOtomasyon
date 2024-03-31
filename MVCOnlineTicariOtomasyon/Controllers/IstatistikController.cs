using MVCOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class IstatistikController : Controller
    {
        Context context = new Context();

        // GET: Istatistik
        public ActionResult Index()
        {
            var value1 = context.Carilers.Count().ToString();
            ViewBag.v1 = value1;
            var value2 = context.Uruns.Count().ToString();
            ViewBag.v2 = value2;
            var value3 = context.Personels.Count().ToString();
            ViewBag.v3 = value3;
            var value4 = context.Kategoris.Count().ToString();
            ViewBag.v4 = value4;
            var value5 = context.Uruns.Sum(x => x.Stok).ToString();
            ViewBag.v5 = value5;
            var value6 = context.Uruns.Select(x => x.Marka).Distinct().Count().ToString();
            ViewBag.v6 = value6;
            var value7 = context.Uruns.Count(x => x.Stok <= 20).ToString();
            ViewBag.v7 = value7;
            var value8 = context.Uruns.OrderByDescending(x => x.SatisFiyat).Select(y => y.UrunAd).FirstOrDefault();
            ViewBag.v8 = value8;
            var value9 = context.Uruns.OrderBy(x => x.SatisFiyat).Select(y => y.UrunAd).FirstOrDefault();
            ViewBag.v9 = value9;
            var value10 = context.Uruns.Count(x => x.UrunAd == "Buzdolabı").ToString();
            ViewBag.v10 = value10;
            var value11 = context.Uruns.Count(x => x.UrunAd == "Laptop").ToString();
            ViewBag.v11 = value11;
            var value12 = context.Uruns.GroupBy(x => x.Marka).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();
            ViewBag.v12 = value12;
            var value13 = context.Uruns.Where(u => u.UrunID == (context.SatisHarekets.GroupBy(x => x.UrunID).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault())).Select(k => k.UrunAd).FirstOrDefault();
            ViewBag.v13 = value13;
            var value14 = context.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.v14 = value14;
            var value15 = context.SatisHarekets.Count(x => x.Tarih == DateTime.Today).ToString();
            ViewBag.v15 = value15;
            var value16 = context.SatisHarekets.Where(x => x.Tarih == DateTime.Today).Count() == 0 ? "0" : context.SatisHarekets.Where(x => x.Tarih == DateTime.Today).Sum(y => y.ToplamTutar).ToString();
            ViewBag.v16 = value16;
            return View();
        }

        public ActionResult Tablolar()
        {
            var values = context.Carilers.GroupBy(x => x.Sehir).Select(y => new Grup
            {
                Sehir = y.Key,
                Adet = y.Count()
            }).ToList();
            return View(values);
        }

        public PartialViewResult Partial1()
        {
            var values = context.Personels.GroupBy(x => x.Departman.DepartmanAd).Select(y => new Grup2
            {
                Departman = y.Key,
                Adet = y.Count()

            }).ToList();
            return PartialView(values);
        }

        public PartialViewResult Partial2()
        {
            var values = context.Carilers.Where(x => x.Durum == true).ToList();
            return PartialView(values);
        }

        public PartialViewResult Partial3()
        {
            var values = context.Uruns.Where(x => x.Durum == true).ToList();
            return PartialView(values);
        }

        public PartialViewResult Partial4()
        {
            var values = context.Uruns.GroupBy(x => x.Marka).Select(y => new Grup3
            {
                Marka = y.Key,
                Adet = y.Count()

            }).ToList();
            return PartialView(values);
        }
    }
}