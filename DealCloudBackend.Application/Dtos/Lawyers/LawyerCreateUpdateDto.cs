// Application/Dtos/Lawyers/LawyerCreateUpdateDto.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DealCloudBackend.Application.Dtos.Lawyers
{
    /// <summary>
    /// DTO para crear o actualizar un Abogado.
    /// </summary>
    public class LawyerCreateUpdateDto
    {
        [Required]
        [StringLength(200)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public int? PositionId { get; set; }
        public int? CountryId { get; set; }
        public int ExperienceYears { get; set; }
        public string ProfileBio { get; set; }

        // IDs para las relaciones Muchos-a-Muchos
        public List<int> PracticeAreaIds { get; set; } = new List<int>();
        public List<int> IndustryIds { get; set; } = new List<int>();
    }
}