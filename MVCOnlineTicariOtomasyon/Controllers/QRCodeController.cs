using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class QRCodeController : Controller
    {
        // GET: QRCode
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string takipKodu)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();
                QRCodeGenerator.QRCode qRCode = qRCodeGenerator.CreateQrCode(takipKodu, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap bmp = qRCode.GetGraphic(10))
                {
                    bmp.Save(ms, ImageFormat.Png);
                    ViewBag.qRCodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
            return View();
        }
    }
}