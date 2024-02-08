using Aplicacion.Query.Usuarios.Dtos;
using AutoMapper;
using Datos.Common;
using Dominio.Common.Enum;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Query.Usuarios
{
    public class ObtenerUsuariosPorCompaniaQueryHandler : IRequestHandler<ObtenerUsuariosPorCompaniaQuery, IEnumerable<UsuarioDTO>>
    {
        private readonly ILogger<ObtenerUsuariosPorCompaniaQueryHandler> _logger;
        private readonly IRepositorioGenerico<Usuario> _repositorioGenerico;
        private readonly IMapper _mapper;

        public ObtenerUsuariosPorCompaniaQueryHandler(ILogger<ObtenerUsuariosPorCompaniaQueryHandler> logger, 
                                                IRepositorioGenerico<Usuario> repositorioGenerico, 
                                                IMapper mapper)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioDTO>> Handle(ObtenerUsuariosPorCompaniaQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _repositorioGenerico.GetAsync(u => u.EstadoId == (int)EstadoEnum.Activo && u.CentroVenta.CompaniaId == request.Id, includeProperties: "CentroVenta,Perfil");
            return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
        }
    }
}
