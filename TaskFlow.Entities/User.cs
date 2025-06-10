using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskFlow.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public ICollection<Gorev> Gorevler { get; set; } = new List<Gorev>();
        public UserRole Role { get; set; } = UserRole.User;
    }
}