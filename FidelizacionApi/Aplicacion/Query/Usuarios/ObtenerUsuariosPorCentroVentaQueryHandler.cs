using Aplicacion.Query.Usuarios.Dtos;
using AutoMapper;
using Datos.Common;
using Dominio.Common.Enum;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Query.Usuarios
{
    public class ObtenerUsuariosPorCentroVentaQueryHandler : IRequestHandler<ObtenerUsuariosPorCentroVentaQuery, IEnumerable<UsuarioDTO>>
    {
        private readonly ILogger<ObtenerUsuariosPorCentroVentaQueryHandler> _logger;
        private readonly IRepositorioGenerico<Usuario> _repositorioGenerico;
        private readonly IMapper _mapper;

        public ObtenerUsuariosPorCentroVentaQueryHandler(ILogger<ObtenerUsuariosPorCentroVentaQueryHandler> logger, 
                                                    IRepositorioGenerico<Usuario> repositorioGenerico, 
                                                    IMapper mapper)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDTO>> Handle(ObtenerUsuariosPorCentroVentaQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _repositorioGenerico.GetAsync(c => c.EstadoId == (int)EstadoEnum.Activo && c.CentroVentaId == request.Id, includeProperties: "CentroVenta,Perfil");
            return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
        }
    }
}
