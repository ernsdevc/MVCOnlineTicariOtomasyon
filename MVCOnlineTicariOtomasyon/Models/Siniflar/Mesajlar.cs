using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.Siniflar
{
    public class Mesajlar
    {
        [Key]
        public int MesajID { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string Gonderici { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string Alici { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        public string Konu { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(200)]
        public string Icerik { get; set; }
        public DateTime Tarih { get; set; }
    }
}