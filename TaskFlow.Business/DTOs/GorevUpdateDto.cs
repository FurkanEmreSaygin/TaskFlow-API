using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskFlow.Business.DTOs
{
    public class GorevUpdateDto
    {
        public string Baslik { get; set; } = null!;
        public string Aciklama { get; set; } = null!;
        public bool TamamlandiMi { get; set; }
    }
}