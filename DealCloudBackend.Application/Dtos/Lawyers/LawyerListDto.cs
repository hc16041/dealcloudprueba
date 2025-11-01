// Application/Dtos/Lawyers/LawyerListDto.cs
namespace DealCloudBackend.Application.Dtos.Lawyers
{
    /// <summary>
    /// DTO ligero para mostrar Abogados en una lista.
    /// </summary>
    public class LawyerListDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PositionName { get; set; } // Aplanado
        public string CountryName { get; set; } // Aplanado
        public int ExperienceYears { get; set; }
    }
}