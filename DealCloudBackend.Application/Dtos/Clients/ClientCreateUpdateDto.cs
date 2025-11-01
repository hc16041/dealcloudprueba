// Application/Dtos/Clients/ClientCreateUpdateDto.cs
using System.ComponentModel.DataAnnotations;

namespace DealCloudBackend.Application.Dtos.Clients
{
    public class ClientCreateUpdateDto
    {
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public int? IndustryId { get; set; }
        public int? CountryId { get; set; }
    }
}