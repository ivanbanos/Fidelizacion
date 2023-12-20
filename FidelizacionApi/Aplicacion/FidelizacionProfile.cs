using Aplicacion.Command.Premios;
using Aplicacion.Query.Premios.Dtos;
using AutoMapper;
using Dominio.Entidades;

namespace Aplicacion
{
    public class FidelizacionProfile : Profile
    {
        public FidelizacionProfile()
        {
            CreateMap<Premio, PremioDTO>()
                .ForMember(dest => dest.FechaInicio, opt => opt.MapFrom(src => src.FechaInicio.ToString("dd/MM/yyyy, HH:mm:ss")))
                .ForMember(dest => dest.FechaFin, opt => opt.MapFrom(src => src.FechaFin.ToString("dd/MM/yyyy, HH:mm:ss")));
            CreateMap<AgregarPremioCommand, Premio>();
        }
    }
}
