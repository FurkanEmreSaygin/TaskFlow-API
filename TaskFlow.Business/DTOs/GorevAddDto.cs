using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskFlow.Business.DTOs
{
    public class GorevAddDto
    {
        public string Baslik { get; set; } = null!;
        public string Aciklama { get; set; } = null!;
        public DateTime Tarih { get; set; } = DateTime.Now;
        public bool TamamlandiMi { get; set; } = false;

        public int UserId { get; set; }
    }
}