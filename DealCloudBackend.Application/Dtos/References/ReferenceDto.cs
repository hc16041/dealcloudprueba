// Application/Dtos/References/ReferenceDto.cs
namespace DealCloudBackend.Application.Dtos.References
{
    public class ReferenceDto
    {
        public int Id { get; set; }
        public int LawyerId { get; set; }
        public string LawyerName { get; set; } // Aplanado
        public string ClientContactName { get; set; }
        public string ClientContactEmail { get; set; }
        public string ClientContactPosition { get; set; }
        public string ClientCompany { get; set; }
    }
}