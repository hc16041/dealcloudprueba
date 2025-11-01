// Application/Dtos/Admin/UserDto.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DealCloudBackend.Application.Dtos.Admin
{
    public class UserCreateDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int FirmId { get; set; } // A qué firma pertenece

        public List<string> Roles { get; set; } = new List<string>();
    }

    public class UserListDto
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string FirmName { get; set; } // Aplanado
        public IList<string> Roles { get; set; }
    }
}