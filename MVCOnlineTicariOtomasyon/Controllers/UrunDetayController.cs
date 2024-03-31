using MVCOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        Context context = new Context();

        // GET: UrunDetay
        public ActionResult Index()
        {
            UrunBilgileri urunBilgileri = new UrunBilgileri();
            urunBilgileri.AnaBilgi = context.Uruns.Where(x => x.UrunID == 1).ToList();
            urunBilgileri.DetayBilgi = context.Detays.Where(x => x.DetayID == 1).ToList();
            return View(urunBilgileri);
        }
    }
}