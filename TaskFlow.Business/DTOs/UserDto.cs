using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskFlow.Entities;

namespace TaskFlow.Business.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string? Token { get; set; }
        public List<GorevDto> Gorevler { get; set; } = new();
        public UserRole Role { get; set; }
    }
}