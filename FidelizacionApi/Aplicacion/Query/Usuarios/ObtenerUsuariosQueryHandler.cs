using Aplicacion.Query.Usuarios.Dtos;
using AutoMapper;
using Datos.Common;
using Dominio.Common.Enum;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Query.Usuarios
{
    public class ObtenerUsuariosQueryHandler : IRequestHandler<ObtenerUsuariosQuery, IEnumerable<UsuarioDTO>>
    {
        private readonly ILogger<ObtenerUsuariosQueryHandler> _logger;
        private readonly IRepositorioGenerico<Usuario> _repositorioGenerico;
        private readonly IMapper _mapper;

        public ObtenerUsuariosQueryHandler(ILogger<ObtenerUsuariosQueryHandler> logger, IRepositorioGenerico<Usuario> repositorioGenerico, IMapper mapper)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDTO>> Handle(ObtenerUsuariosQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _repositorioGenerico.GetAsync(c => c.EstadoId == (int)EstadoEnum.Activo, includeProperties: "CentroVenta,Perfil");
            return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
        }
    }
}
