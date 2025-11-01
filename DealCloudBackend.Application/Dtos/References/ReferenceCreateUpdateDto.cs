using DealCloudBackend.Application.Dtos.References;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel.DataAnnotations;

namespace DealCloudBackend.Application.Dtos.References
{
    public class ReferenceCreateUpdateDto
    {
        [Required]
        public int LawyerId { get; set; } // Abogado al que se refiere

        [Required]
        public string ClientContactName { get; set; }

        [EmailAddress]
        public string ClientContactEmail { get; set; }
        public string ClientContactPosition { get; set; }
        [Required]
        public string ClientCompany { get; set; }
    }
}