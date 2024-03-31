using MVCOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        Context context = new Context();

        // GET: Kargo
        public ActionResult Index(string takipNo)
        {
            var values = context.KargoDetays.ToList();
            if (!String.IsNullOrEmpty(takipNo))
            {
                values = values.Where(x => x.TakipKodu.Contains(takipNo)).ToList();
            }
            return View(values);
        }

        [HttpGet]
        public ActionResult YeniKargo()
        {
            Random random = new Random();
            string[] karakterler = { "A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "V", "Y", "Z" };
            int k1, k2, k3;
            k1 = random.Next(0, karakterler.Length);
            k2 = random.Next(0, karakterler.Length);
            k3 = random.Next(0, karakterler.Length);
            int s1, s2, s3;
            s1 = random.Next(100, 1000);
            s2 = random.Next(10, 99);
            s3 = random.Next(10, 99);
            string takipKodu = s1.ToString() + karakterler[k1] + s2.ToString() + karakterler[k2] + s3.ToString() + karakterler[k3];
            ViewBag.takipKodu = takipKodu;
            List<SelectListItem> value1 = (from x in context.Personels.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.PersonelAd + " " + x.PersonelSoyad,
                                              Value = x.PersonelAd + " " + x.PersonelSoyad
                                          }).ToList();
            ViewBag.v1 = value1;

            List<SelectListItem> value2 = (from x in context.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariAd + " " + x.CariSoyad
                                           }).ToList();
            ViewBag.v2 = value2;
            return View();
        }

        [HttpPost]
        public ActionResult YeniKargo(KargoDetay kargo)
        {
            context.KargoDetays.Add(kargo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult KargoTakip(string takipNo)
        {
            var values = context.KargoTakips.Where(x => x.TakipKodu == takipNo).ToList();
            return PartialView(values);
        }
    }
}