// Application/Dtos/ProBono/ProBonoCreateUpdateDto.cs
using System.ComponentModel.DataAnnotations;

namespace DealCloudBackend.Application.Dtos.ProBono
{
    public class ProBonoCreateUpdateDto
    {
        [Required]
        public string CaseName { get; set; }
        public string ClientDescription { get; set; }
        [Required]
        public string CaseDescription { get; set; }
        // ... otros campos específicos que pidan los directorios
    }
}