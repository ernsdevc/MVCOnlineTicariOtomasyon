using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.Siniflar
{
    public class UrunBilgileri
    {
        public IEnumerable<Urun> AnaBilgi { get; set; }
        public IEnumerable<Detay> DetayBilgi { get; set; }
    }
}