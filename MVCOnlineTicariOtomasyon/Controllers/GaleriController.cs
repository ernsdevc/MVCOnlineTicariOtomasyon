using MVCOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class GaleriController : Controller
    {
        Context context = new Context();

        // GET: Galeri
        public ActionResult Index()
        {
            var values = context.Uruns.Where(x => x.Durum == true).ToList();
            return View(values);
        }
    }
}