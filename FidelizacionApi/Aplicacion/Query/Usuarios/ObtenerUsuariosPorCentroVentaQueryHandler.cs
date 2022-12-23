using Datos.Common;
using Dominio.Common.Enum;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Query.Usuarios
{
    public class ObtenerUsuariosPorCentroVentaQueryHandler : IRequestHandler<ObtenerUsuariosPorCentroVentaQuery, IEnumerable<Dominio.Entidades.Usuario>>
    {
        private readonly ILogger<ObtenerUsuariosPorCentroVentaQueryHandler> _logger;
        private readonly IRepositorioGenerico<Dominio.Entidades.Usuario> _repositorioGenerico;

        public ObtenerUsuariosPorCentroVentaQueryHandler(ILogger<ObtenerUsuariosPorCentroVentaQueryHandler> logger, IRepositorioGenerico<Dominio.Entidades.Usuario> repositorioGenerico)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
        }

        public Task<IEnumerable<Dominio.Entidades.Usuario>> Handle(ObtenerUsuariosPorCentroVentaQuery request, CancellationToken cancellationToken)
        {
            return _repositorioGenerico.GetAsync(c => c.EstadoId == (int)EstadoEnum.Activo && c.CentroVentaId == request.Id, includeProperties: "CentroVenta");
        }
    }
}
