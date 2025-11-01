// Application/Dtos/Reports/ReferenceReportGenerateRequestDto.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DealCloudBackend.Application.Dtos.Reports
{
    public class ReferenceReportGenerateRequestDto
    {
        [Required]
        public string TemplateName { get; set; } // "Chambers_References", etc.

        [Required]
        [MinLength(1)]
        public List<int> ReferenceIds { get; set; }
    }
}