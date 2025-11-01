using System.ComponentModel.DataAnnotations; // <-- ESTA LÍNEA FALTABA

namespace DealCloudBackend.Application.Dtos.Admin
{
    public class RoleAssignDto
    {
        [Required] // Ahora será reconocido
        public string UserId { get; set; }
        [Required] // Ahora será reconocido
        public string RoleName { get; set; }
    }
}