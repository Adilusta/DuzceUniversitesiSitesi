using System.ComponentModel.DataAnnotations;
using System;

namespace Web_Vize_Proje.Models
{
    public class Duyuru
    {
        [Key]
        public int DuyuruID { get; set; }
        [StringLength(100000, MinimumLength = 200)]
        public string DuyuruBasligi { get; set; }
        [StringLength(100000, MinimumLength =200)]
        public string DuyuruAciklamasi { get; set; }
        public DateTime DuyuruTarihi { get; set; }
    }
}
