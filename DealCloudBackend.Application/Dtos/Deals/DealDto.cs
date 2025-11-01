// Application/Dtos/Deals/DealDto.cs
using DealCloudBackend.Application.Dtos.Lawyers;
using DealCloudBackend.Application.Dtos.Shared;
using System.Collections.Generic;

namespace DealCloudBackend.Application.Dtos.Deals
{
    /// <summary>
    /// DTO detallado para ver la ficha completa de un Caso (Deal).
    /// </summary>
    public class DealDto
    {
        public int Id { get; set; }
        public string ReferenceNumber { get; set; }
        public string DealName { get; set; }
        public bool IsConfidential { get; set; }
        public string Description { get; set; }
        public string OtherFirmsInvolved { get; set; }
        public string Notes { get; set; }

        public SimpleCatalogDto Client { get; set; }
        public SimpleCatalogDto PracticeArea { get; set; }

        public ICollection<LawyerListDto> Team { get; set; } = new List<LawyerListDto>();
    }
}