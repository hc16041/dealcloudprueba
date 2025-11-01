// Application/Dtos/Deals/DealCreateUpdateDto.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DealCloudBackend.Application.Dtos.Deals
{
    public class DealCreateUpdateDto
    {
        [Required]
        [StringLength(250)]
        public string DealName { get; set; }
        public bool IsConfidential { get; set; }

        [Required]
        public string Description { get; set; }

        public string OtherFirmsInvolved { get; set; }
        public string Notes { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        public int PracticeAreaId { get; set; }

        // IDs de los abogados en el equipo
        public List<int> TeamMemberLawyerIds { get; set; } = new List<int>();
    }
}