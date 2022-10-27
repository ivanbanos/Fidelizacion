using Datos.Common;
using Dominio.Common.Enum;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Query.CentroVentas
{
    public class ObtenerCentroVentasQueryHandler : IRequestHandler<ObtenerCentroVentasQuery, IEnumerable<CentroVenta>>
    {
        private readonly ILogger<ObtenerCentroVentasQueryHandler> _logger;
        private readonly IRepositorioGenerico<CentroVenta> _repositorioGenerico;

        public ObtenerCentroVentasQueryHandler(ILogger<ObtenerCentroVentasQueryHandler> logger, IRepositorioGenerico<CentroVenta> repositorioGenerico)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
        }

        public Task<IEnumerable<CentroVenta>> Handle(ObtenerCentroVentasQuery request, CancellationToken cancellationToken)
        {
            return _repositorioGenerico.GetAsync(cv => cv.EstadoId == (int)EstadoEnum.Activo);

        }
    }
}
