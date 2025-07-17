using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskFlow.Business.DTOs
{
    public class GorevAddDto
    {
        [Required(ErrorMessage = "Başlık zorunludur.")]
        [MaxLength(100, ErrorMessage = "Başlık en fazla 100 karakter olabilir.")]
        public string Baslik { get; set; } = null!;
        [Required(ErrorMessage = "Açıklama zorunludur.")]
        [MaxLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
        public string Aciklama { get; set; } = null!;
        public DateTime Tarih { get; set; } = DateTime.Now;
        public bool TamamlandiMi { get; set; } = false;

        [Range(1, int.MaxValue, ErrorMessage = "Geçerli bir kullanıcı ID'si giriniz.")]
        public int UserId { get; set; }
    }
}