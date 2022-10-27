using Datos.Common;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Query.CentroVentas
{
    public class ObtenerCentroVentaHandler : IRequestHandler<ObtenerCentroVentaQuery, CentroVenta>
    {
        private readonly ILogger<ObtenerCentroVentaHandler> _logger;
        private readonly IRepositorioGenerico<CentroVenta> _repositorioGenerico;

        public ObtenerCentroVentaHandler(ILogger<ObtenerCentroVentaHandler> logger, IRepositorioGenerico<CentroVenta> repositorioGenerico)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
        }

        public Task<CentroVenta> Handle(ObtenerCentroVentaQuery request, CancellationToken cancellationToken)
        {
            return _repositorioGenerico.GetByIdAsync(request.Id);

        }
    }
}
