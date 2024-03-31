using MVCOnlineTicariOtomasyon.Models.Siniflar;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        Context context = new Context();

        // GET: CariPanel

        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["Mail"];
            var values = context.Carilers.FirstOrDefault(x => x.Mail == mail);
            ViewBag.adSoyad = values.CariAd + " " + values.CariSoyad;
            ViewBag.mail = mail;
            ViewBag.sehir = values.Sehir;
            var toplamSatis = context.SatisHarekets.Where(x => x.CariID == values.CariID).Count();
            ViewBag.toplamSatis = toplamSatis;
            var toplamTutar = context.SatisHarekets.Where(x => x.CariID == values.CariID).Sum(y => y.ToplamTutar);
            ViewBag.toplamTutar = toplamTutar;
            var toplamUrunSayisi = context.SatisHarekets.Where(x => x.CariID == values.CariID).Sum(y => y.Adet);
            ViewBag.toplamUrunSayisi = toplamUrunSayisi;
            var mesajlar = context.Mesajlars.Where(x => x.Alici == mail).ToList();
            return View(mesajlar);
        }

        [Authorize]
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["Mail"];
            var id = context.Carilers.FirstOrDefault(x => x.Mail == mail).CariID;
            var values = context.SatisHarekets.Where(x => x.CariID == id).ToList();
            return View(values);
        }

        [Authorize]
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["Mail"];
            var values = context.Mesajlars.Where(x => x.Alici == mail).OrderByDescending(y => y.Tarih).ToList();
            var gonderilenMesajSayisi = context.Mesajlars.Where(x => x.Gonderici == mail).Count();
            ViewBag.v = gonderilenMesajSayisi;
            return View(values);
        }

        [Authorize]
        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["Mail"];
            var values = context.Mesajlars.Where(x => x.Gonderici == mail).ToList();
            var gelenMesajSayisi = context.Mesajlars.Where(x => x.Alici == mail).Count();
            ViewBag.v = gelenMesajSayisi;
            return View(values);
        }

        [Authorize]
        public ActionResult MesajDetay(int id)
        {
            var values = context.Mesajlars.Find(id);
            var gelenMesajSayisi = context.Mesajlars.Where(x => x.Alici == values.Alici).Count();
            ViewBag.v1 = gelenMesajSayisi;
            var gonderilenMesajSayisi = context.Mesajlars.Where(x => x.Gonderici == values.Alici).Count();
            ViewBag.v2 = gonderilenMesajSayisi;
            return View(values);
        }

        [Authorize]
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            var mail = (string)Session["Mail"];
            var gelenMesajSayisi = context.Mesajlars.Where(x => x.Alici == mail).Count();
            ViewBag.v1 = gelenMesajSayisi;
            var gonderilenMesajSayisi = context.Mesajlars.Where(x => x.Gonderici == mail).Count();
            ViewBag.v2 = gonderilenMesajSayisi;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar mesaj)
        {
            var mail = (string)Session["Mail"];
            mesaj.Gonderici = mail;
            mesaj.Tarih = DateTime.Now.Date;
            context.Mesajlars.Add(mesaj);
            context.SaveChanges();
            return RedirectToAction("GelenMesajlar");
        }

        [Authorize]
        public ActionResult KargoTakip(string takipNo)
        {
            var values = context.KargoDetays.Where(x => x.TakipKodu.Contains(takipNo)).ToList();
            return View(values);
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index");
        }

        public ActionResult Partial1()
        {
            var mail = (string)Session["Mail"];
            var values = context.Carilers.FirstOrDefault(x => x.Mail == mail);
            return PartialView("Partial1", values);
        }

        public ActionResult Partial2()
        {
            var mail = (string)Session["Mail"];
            var values = context.Mesajlars.Where(x => x.Gonderici == "admin").ToList();
            return PartialView(values);
        }

        public ActionResult CariBilgiGuncelle(Cariler cari)
        {
            var mail = (string)Session["Mail"];
            var cariID = context.Carilers.Where(x => x.Mail == mail).Select(y => y.CariID).FirstOrDefault();
            var values = context.Carilers.Find(cariID);
            values.CariAd = cari.CariAd;
            values.CariSoyad = cari.CariSoyad;
            values.Sehir = cari.Sehir;
            values.Mail = cari.Mail;
            values.Sifre = cari.Sifre;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}