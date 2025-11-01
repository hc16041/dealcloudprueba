// Application/Dtos/Admin/LoginDto.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DealCloudBackend.Application.Dtos.Admin
{
    public class LoginRequestDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class LoginResponseDto
    {
        public string Token { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int FirmId { get; set; } // Clave para el multi-tenancy en el frontend
        public IList<string> Roles { get; set; }
    }
}