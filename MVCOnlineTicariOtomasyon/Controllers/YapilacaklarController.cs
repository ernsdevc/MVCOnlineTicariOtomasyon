using MVCOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class YapilacaklarController : Controller
    {
        Context context = new Context();

        // GET: Yapilacaklar
        public ActionResult Index()
        {
            var value1 = context.Carilers.Count().ToString();
            ViewBag.v1 = value1;
            var value2 = context.Uruns.Count().ToString();
            ViewBag.v2 = value2;
            var value3 = context.Kategoris.Count().ToString();
            ViewBag.v3 = value3;
            var value4 = context.Carilers.Select(x => x.Sehir).Distinct().Count().ToString();
            ViewBag.v4 = value4;

            var values = context.Yapilacaklars.Where(x => x.Durum == true).ToList();
            return View(values);
        }
    }
}