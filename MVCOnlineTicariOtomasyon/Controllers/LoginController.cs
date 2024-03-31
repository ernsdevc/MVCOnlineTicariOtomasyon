using MVCOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        Context context = new Context();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult Partial1(Cariler cari)
        {
            context.Carilers.Add(cari);
            context.SaveChanges();
            return PartialView();
        }

        [HttpGet]
        public ActionResult CariLogin()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult CariLogin(Cariler cari)
        {
            var values = context.Carilers.FirstOrDefault(x => x.Mail == cari.Mail && x.Sifre == cari.Sifre);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Mail, false);
                Session["Mail"] = values.Mail;  
                return RedirectToAction("Index", "CariPanel");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var values = context.Admins.FirstOrDefault(x => x.KullaniciAd == admin.KullaniciAd && x.Sifre == admin.Sifre);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.KullaniciAd, false);
                Session["KullaniciAd"] = values.KullaniciAd;
                return RedirectToAction("Index", "Kategori");
            }
            return RedirectToAction("Index");
        }
    }
}