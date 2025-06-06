using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskFlow.Business.DTOs
{
    public class GorevUpdateDto
    {
        [Required(ErrorMessage = "Başlık zorunludur.")]
        [MaxLength(100, ErrorMessage = "Başlık en fazla 100 karakter olabilir.")]
        public string Baslik { get; set; } = null!;
        [Required(ErrorMessage = "Açıklama zorunludur.")]
        [MaxLength(500, ErrorMessage = "Açıklama en fazla 500 karakter olabilir.")]
        public string Aciklama { get; set; } = null!;
        public bool TamamlandiMi { get; set; }
    }
}