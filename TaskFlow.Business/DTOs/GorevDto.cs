using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskFlow.Business.DTOs
{
    public class GorevDto
    {
        public int Id { get; set; }
        public string Baslik { get; set; } = null!;
        public string Aciklama { get; set; } = null!;
        public DateTime Tarih { get; set; }
        public bool TamamlandiMi { get; set; }
    }
}