// Application/Dtos/Lawyers/LawyerDto.cs
using DealCloudBackend.Application.Dtos.Shared;
using System.Collections.Generic;

namespace DealCloudBackend.Application.Dtos.Lawyers
{
	/// <summary>
	/// DTO detallado para ver el perfil completo de un Abogado.
	/// </summary>
	public class LawyerDto
	{
		public int Id { get; set; }
		public string FullName { get; set; }
		public string Email { get; set; }
		public int ExperienceYears { get; set; }
		public string ProfileBio { get; set; }

		public SimpleCatalogDto Position { get; set; }
		public SimpleCatalogDto Country { get; set; }

		public ICollection<SimpleCatalogDto> PracticeAreas { get; set; } = new List<SimpleCatalogDto>();
		public ICollection<SimpleCatalogDto> Industries { get; set; } = new List<SimpleCatalogDto>();
	}
}