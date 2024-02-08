using Aplicacion.Command.CentroVentas;
using Aplicacion.Command.Companias;
using Aplicacion.Command.Fidelizados;
using Aplicacion.Command.Premios;
using Aplicacion.Command.Usuarios;
using Aplicacion.Query.CentroVentas.Dtos;
using Aplicacion.Query.Companias.Dtos;
using Aplicacion.Query.Fidelizados.Dtos;
using Aplicacion.Query.Premios.Dtos;
using Aplicacion.Query.Usuarios.Dtos;
using AutoMapper;
using Dominio.Entidades;

namespace Aplicacion
{
    public class FidelizacionProfile : Profile
    {
        public FidelizacionProfile()
        {
            CreateMap<AgregarCentroVentaCommand, CentroVenta>();
            CreateMap<CentroVenta, CentroVentaDto>();
            CreateMap<AgregarCompaniaCommand, Compania>();
            CreateMap<Compania, CompaniaDto>();
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
                .ForMember(dest => dest.NombreCiudad, opt => opt.MapFrom(src => src.InformacionAdicional.Ciudad.Nombre))
                .ForMember(dest => dest.ProfesionId, opt => opt.MapFrom(src => src.InformacionAdicional.ProfesionId));
            CreateMap<Dominio.Dtos.FidelizadoDto, FidelizadoDto>();
            CreateMap<Premio, PremioDTO>()
                .ForMember(dest => dest.FechaInicio, opt => opt.MapFrom(src => src.FechaInicio.ToString("dd/MM/yyyy, HH:mm:ss")))
                .ForMember(dest => dest.FechaFin, opt => opt.MapFrom(src => src.FechaFin.ToString("dd/MM/yyyy, HH:mm:ss")));
            CreateMap<AgregarPremioCommand, Premio>();
            CreateMap<CrearUsuarioCommand, Usuario>()
                .ForMember(dest => dest.NombreUsuario, opt => opt.MapFrom(src => src.NombreUsuario))
                .ForMember(dest => dest.PerfilId, opt => opt.MapFrom(src => src.Perfil))
                .ForMember(dest => dest.CentroVentaId, opt => opt.MapFrom(src => src.CentroVentaId));
            CreateMap<Usuario, UsuarioDTO>()
                .ForMember(dest => dest.NombreCentroVenta, opt => opt.MapFrom(src => src.CentroVenta.Nombre))
                .ForMember(dest => dest.Perfil, opt => opt.MapFrom(src => src.Perfil.Nombre));

        }
    }
}
