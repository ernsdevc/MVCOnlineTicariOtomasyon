using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCOnlineTicariOtomasyon.Models.Siniflar
{
    public class CascadeUrunKategori
    {
        public IEnumerable<SelectListItem> Kategori { get; set; }
        public IEnumerable<SelectListItem> Urunler { get; set; }
    }
}