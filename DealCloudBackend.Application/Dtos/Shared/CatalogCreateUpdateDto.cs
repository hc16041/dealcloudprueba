// Application/Dtos/Shared/CatalogCreateUpdateDto.cs
using System.ComponentModel.DataAnnotations;

namespace DealCloudBackend.Application.Dtos.Shared
{
    /// <summary>
    /// DTO genérico para crear o actualizar entidades de catálogo simples 
    /// (Positions, PracticeAreas, Industries)
    /// </summary>
    public class CatalogCreateUpdateDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}