using Aplicacion.Command.Fidelizados;
using Aplicacion.Command.Premios;
using Aplicacion.Query.Fidelizados.Dtos;
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
            CreateMap<AgregarFidelizadoCommand, Fidelizado>()
                .ForMember(dest => dest.InformacionAdicional, 
                    opt => opt.MapFrom(src => new InformacionAdicional 
                    { 
                        Telefono = src.Telefono,
                        Celular = src.Celular,
                        Direccion = src.Direccion,
                        Estrato = src.Estrato,
                        NumeroHijos = src.NumeroHijos,
                        SexoId = src.SexoId,
                        CiudadId = src.CiudadId,
                        ProfesionId = src.ProfesionId
                    }));
            CreateMap<Fidelizado, FidelizadoDto>()
                .ForMember(dest => dest.Telefono, opt => opt.MapFrom(src => src.InformacionAdicional.Telefono))
                .ForMember(dest => dest.Celular, opt => opt.MapFrom(src => src.InformacionAdicional.Celular))
                .ForMember(dest => dest.Direccion, opt => opt.MapFrom(src => src.InformacionAdicional.Direccion))
                .ForMember(dest => dest.Estrato, opt => opt.MapFrom(src => src.InformacionAdicional.Estrato))
                .ForMember(dest => dest.NumeroHijos, opt => opt.MapFrom(src => src.InformacionAdicional.NumeroHijos))
                .ForMember(dest => dest.SexoId, opt => opt.MapFrom(src => src.InformacionAdicional.SexoId))
                .ForMember(dest => dest.CiudadId, opt => opt.MapFrom(src => src.InformacionAdicional.CiudadId))
                .ForMember(dest => dest.ProfesionId, opt => opt.MapFrom(src => src.InformacionAdicional.ProfesionId));
        }
    }
}
