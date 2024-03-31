using MVCOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        Context context = new Context();

        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            var grafik = new Chart(600, 600);
            grafik.AddTitle("Kategori - Ürün Stok Sayısı").AddLegend("Stok").AddSeries("Değerler", xValue:new[] {"Mobilya", "Ofis Eşyaları", "Bilgisayar"}, yValues:new[] {85,66,98}).Write();
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult Index3()
        {
            ArrayList xValues = new ArrayList();
            ArrayList yValues = new ArrayList();
            var sonuclar = context.Uruns.ToList();
            sonuclar.ForEach(x => xValues.Add(x.UrunAd));
            sonuclar.ForEach(x => yValues.Add(x.Stok));
            var grafik = new Chart(800,800).AddTitle("Stoklar").AddSeries(chartType:"Pie", name:"Stok", xValue:xValues, yValues:yValues);
            return File(grafik.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult Index4()
        {
            return View();
        }

        public ActionResult VisualizeUrunResult()
        {
            return Json(UrunListesi(), JsonRequestBehavior.AllowGet);
        }

        public List<Grafik> UrunListesi()
        {
            List<Grafik> grf = new List<Grafik>();
            grf.Add(new Grafik
            {
                UrunAd = "Bilgisayar",
                Stok = 120
            });
            grf.Add(new Grafik
            {
                UrunAd = "Beyaz Eşya",
                Stok = 150
            });
            grf.Add(new Grafik
            {
                UrunAd = "Mobilya",
                Stok = 70
            });
            grf.Add(new Grafik
            {
                UrunAd = "Küçük Ev Aletleri",
                Stok = 80
            });
            grf.Add(new Grafik
            {
                UrunAd = "Mobil Cihazlar",
                Stok = 90
            });

            return grf;
        }

        public ActionResult Index5()
        {
            return View();
        }

        public ActionResult VisualizeUrunResult2()
        {
            return Json(UrunListesi2(), JsonRequestBehavior.AllowGet);
        }

        public List<Grafik> UrunListesi2()
        {
            List<Grafik> grf = new List<Grafik>();
            using (var context = new Context())
            {
                grf = context.Uruns.Select(x => new Grafik { 
                UrunAd = x.UrunAd,
                Stok = x.Stok
                }).ToList();
            }

            return grf;
        }

        public ActionResult Index6()
        {
            return View();
        }

        public ActionResult Index7()
        {
            return View();
        }
    }
}