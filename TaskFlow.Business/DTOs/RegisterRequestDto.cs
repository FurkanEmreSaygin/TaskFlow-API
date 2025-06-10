using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TaskFlow.Entities;

namespace TaskFlow.Business.DTOs
{
    public class RegisterRequestDto
    {
        [Required(ErrorMessage = "Email alanı boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        [MaxLength(20, ErrorMessage = "Şifre en fazla 20 karakter olmalıdır.")]
        public string Password { get; set; } = null!;
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public UserRole Role { get; set; }
    }
}