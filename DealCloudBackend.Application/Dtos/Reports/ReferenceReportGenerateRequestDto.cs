// Application/Dtos/Reports/ReportGenerateRequestDto.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DealCloudBackend.Application.Dtos.Reports
{
    public class ReportGenerateRequestDto
    {
        [Required]
        public string TemplateName { get; set; } // "Chambers", "IFLR", etc.

        [Required]
        [MinLength(1)]
        public List<int> DealIds { get; set; }
    }
}