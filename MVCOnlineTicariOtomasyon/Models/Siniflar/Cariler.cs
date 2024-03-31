using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCOnlineTicariOtomasyon.Models.Siniflar
{
    public class Cariler
    {
        [Key]
        public int CariID { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter girebilirsiniz.")]
        public string CariAd { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(30)]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string CariSoyad { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(13)]
        public string Sehir { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(30)]
        public string Mail { get; set; }
        [Column(TypeName = "nvarchar")]
        [StringLength(20)]
        public string Sifre { get; set; }
        public bool Durum { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}