// Application/Dtos/Deals/DealListDto.cs
namespace DealCloudBackend.Application.Dtos.Deals
{
    /// <summary>
    /// DTO ligero para mostrar Casos (Deals) en una lista.
    /// </summary>
    public class DealListDto
    {
        public int Id { get; set; }
        public string ReferenceNumber { get; set; }
        public string DealName { get; set; }
        public string ClientName { get; set; } // Aplanado
        public string PracticeAreaName { get; set; } // Aplanado
        public bool IsConfidential { get; set; }
    }
}