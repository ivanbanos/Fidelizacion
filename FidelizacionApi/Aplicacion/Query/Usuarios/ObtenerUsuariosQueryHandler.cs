using Datos.Common;
using Dominio.Common.Enum;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Query.Usuarios
{
    public class ObtenerUsuariosQueryHandler : IRequestHandler<ObtenerUsuariosQuery, IEnumerable<Dominio.Entidades.Usuario>>
    {
        private readonly ILogger<ObtenerUsuariosQueryHandler> _logger;
        private readonly IRepositorioGenerico<Dominio.Entidades.Usuario> _repositorioGenerico;

        public ObtenerUsuariosQueryHandler(ILogger<ObtenerUsuariosQueryHandler> logger, IRepositorioGenerico<Dominio.Entidades.Usuario> repositorioGenerico)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
        }

        public Task<IEnumerable<Dominio.Entidades.Usuario>> Handle(ObtenerUsuariosQuery request, CancellationToken cancellationToken)
        {
            return _repositorioGenerico.GetAsync(c => c.EstadoId == (int)EstadoEnum.Activo, includeProperties: "CentroVenta");
        }
    }
}
