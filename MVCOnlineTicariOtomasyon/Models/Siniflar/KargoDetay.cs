using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.Siniflar
{
    public class KargoDetay
    {
        [Key]
        public int DetayID { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(300)]
        public string Aciklama { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(10)]
        public string TakipKodu { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(20)]
        public string Personel { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(20)]
        public string Alici { get; set; }
        public DateTime Tarih { get; set; }
    }
}