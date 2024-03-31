using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.Siniflar
{
    public class KargoTakip
    {
        [Key]
        public int TakipID { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(10)]
        public string TakipKodu { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        public string Aciklama { get; set; }
        public DateTime TarihSaat { get; set; }
    }
}