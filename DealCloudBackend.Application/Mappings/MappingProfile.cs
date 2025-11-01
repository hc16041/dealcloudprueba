using AutoMapper;
using DealCloudBackend.Application.Dtos.Clients;
using DealCloudBackend.Application.Dtos.Deals;
using DealCloudBackend.Application.Dtos.Lawyers;
using DealCloudBackend.Core;

namespace DealCloudBackend.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Abogados (Lawyers)
            CreateMap<LawyerCreateUpdateDto, Lawyer>(); // De DTO a Entidad
            CreateMap<Lawyer, LawyerDto>(); // De Entidad a DTO
            CreateMap<Lawyer, LawyerListDto>() // De Entidad a DTO de Lista (aplanado)
                .ForMember(dest => dest.PositionName, opt => opt.MapFrom(src => src.Position.Name))
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name));

            // Clientes (Clients)
            CreateMap<ClientCreateUpdateDto, Client>();
            CreateMap<Client, ClientDto>()
                .ForMember(dest => dest.Industry, opt => opt.MapFrom(src => src.Industry))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country));

            // Casos (Deals)
            CreateMap<DealCreateUpdateDto, Deal>();
            CreateMap<Deal, DealDto>();
            CreateMap<Deal, DealListDto>()
                .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Client.Name))
                .ForMember(dest => dest.PracticeAreaName, opt => opt.MapFrom(src => src.PracticeArea.Name));

            // ... Agrega el resto de tus mapeos aquí (ProBono, References, etc.) ...
        }
    }
}