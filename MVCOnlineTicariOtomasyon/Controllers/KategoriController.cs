using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCOnlineTicariOtomasyon.Models.Siniflar;
using PagedList;
using PagedList.Mvc;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        Context context = new Context();

        public ActionResult Index(int sayfa = 1)
        {
            var values =  context.Kategoris.ToList().ToPagedList(sayfa, 4);
            return View(values);
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori kategori)
        {
            context.Kategoris.Add(kategori);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var kategori = context.Kategoris.Find(id);
            context.Kategoris.Remove(kategori);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = context.Kategoris.Find(id);
            return View("KategoriGetir", kategori);
        }

        public ActionResult KategoriGuncelle(Kategori kategori)
        {
            var k = context.Kategoris.Find(kategori.KategoriID);
            k.KategoriAd = kategori.KategoriAd;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriUrun()
        {
            CascadeUrunKategori cascadeUrunKategori = new CascadeUrunKategori();
            cascadeUrunKategori.Kategori = new SelectList(context.Kategoris, "KategoriID", "KategoriAd");
            cascadeUrunKategori.Urunler = new SelectList(context.Uruns.Where(x => x.Durum == true), "UrunID", "UrunAd");
            return View(cascadeUrunKategori);
        }

        public JsonResult KategoriyeGoreUrunGetir(int id)
        {
            var values = (from x in context.Uruns.Where(x => x.Durum == true)
                          join y in context.Kategoris
                          on x.Kategori.KategoriID equals y.KategoriID
                          where x.Kategori.KategoriID == id
                          select new
                          {
                              Text = x.UrunAd,
                              Value = x.UrunID
                          }).ToList();
            return Json(values, JsonRequestBehavior.AllowGet);
        }
    }
}