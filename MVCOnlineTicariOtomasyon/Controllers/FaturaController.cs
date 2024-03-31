using MVCOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        Context context = new Context();

        // GET: Fatura
        public ActionResult Index()
        {
            var values = context.Faturalars.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(Faturalar fatura)
        {
            context.Faturalars.Add(fatura);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaGetir(int id)
        {
            var values = context.Faturalars.Find(id);
            return View("FaturaGetir", values);
        }

        public ActionResult FaturaGuncelle(Faturalar fatura)
        {
            var values = context.Faturalars.Find(fatura.FaturaID);
            values.FaturaSeriNo = fatura.FaturaSeriNo;
            values.FaturaSiraNo = fatura.FaturaSiraNo;
            values.Tarih = fatura.Tarih;
            values.Saat = fatura.Saat;
            values.VergiDairesi = fatura.VergiDairesi;
            values.TeslimEden = fatura.TeslimEden;
            values.TeslimAlan = fatura.TeslimAlan;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {
            var values = context.FaturaKalems.Where(x => x.FaturaID == id).ToList();
            var fatura = context.Faturalars.Find(id);
            ViewBag.v = fatura.FaturaSeriNo.ToString() + fatura.FaturaSiraNo.ToString();
            return View(values);
        }

        [HttpGet]
        public ActionResult YeniKalem(int id)
        {
            ViewBag.v = id;
            return View();
        }

        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem faturaKalem)
        {
            context.FaturaKalems.Add(faturaKalem);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DinamikFaturalar()
        {
            DinamikFatura dinamikFatura = new DinamikFatura();
            dinamikFatura.Fatura = context.Faturalars.ToList();
            dinamikFatura.FaturaKalem = context.FaturaKalems.ToList();
            return View(dinamikFatura);
        }

        public ActionResult FaturaKaydet(string faturaSeriNo, string faturaSiraNo, DateTime tarih, string vergiDairesi, string saat, string teslimEden, string teslimAlan, string toplam, FaturaKalem[] faturaKalem)
        {
            Faturalar faturalar = new Faturalar();
            faturalar.FaturaSeriNo = faturaSeriNo;
            faturalar.FaturaSiraNo = faturaSiraNo;
            faturalar.Tarih = tarih;
            faturalar.VergiDairesi = vergiDairesi;
            faturalar.Saat = saat;
            faturalar.TeslimEden = teslimEden;
            faturalar.TeslimAlan = teslimAlan;
            faturalar.Toplam = decimal.Parse(toplam);
            context.Faturalars.Add(faturalar);
            foreach (var item in faturaKalem)
            {
                FaturaKalem faturaKalems = new FaturaKalem();
                faturaKalems.FaturaID = item.FaturaID;
                faturaKalems.Aciklama = item.Aciklama;
                faturaKalems.Miktar = item.Miktar;
                faturaKalems.BirimFiyat = item.BirimFiyat;
                faturaKalems.Tutar = item.Tutar;
                context.FaturaKalems.Add(faturaKalems);
            }
            context.SaveChanges();
            return Json("İşlem Başarılı.", JsonRequestBehavior.AllowGet);
        }
    }
}