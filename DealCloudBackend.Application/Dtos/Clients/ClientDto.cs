// Application/Dtos/Clients/ClientDto.cs
using DealCloudBackend.Application.Dtos.Shared;
using DealCloudBackend.Application.Dtos.Deals;
using System.Collections.Generic;

namespace DealCloudBackend.Application.Dtos.Clients
{
    /// <summary>
    /// DTO detallado para ver un Cliente y sus casos asociados.
    /// </summary>
    public class ClientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public SimpleCatalogDto Industry { get; set; }
        public SimpleCatalogDto Country { get; set; }

        // Opcional: Incluir los casos (Deals) asociados a este cliente
        public ICollection<DealListDto> Deals { get; set; } = new List<DealListDto>();
    }
}