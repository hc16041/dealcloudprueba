// Application/Dtos/ProBono/ProBonoDto.cs
namespace DealCloudBackend.Application.Dtos.ProBono
{
    public class ProBonoDto
    {
        public int Id { get; set; }
        public string ReferenceNumber { get; set; }
        public string CaseName { get; set; }
        public string ClientDescription { get; set; }
        public string CaseDescription { get; set; }
    }
}