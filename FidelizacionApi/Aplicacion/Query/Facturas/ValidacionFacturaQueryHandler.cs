using Aplicacion.Exepciones;
using Datos.Common;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Aplicacion.Query.Facturas
{
    public class ValidacionFacturaQueryHandler : IRequestHandler<ValidacionFacturaQuery, bool>
    {
        private readonly ILogger<ValidacionFacturaQueryHandler> _logger;
        private readonly IRepositorioGenerico<Punto> _repositorioGenerico;
        private readonly IRepositorioGenerico<CentroVenta> _repositorioCentroVenta;

        public ValidacionFacturaQueryHandler(ILogger<ValidacionFacturaQueryHandler> logger, IRepositorioGenerico<Punto> repositorioGenerico, IRepositorioGenerico<CentroVenta> repositorioCentroVenta)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repositorioGenerico = repositorioGenerico ?? throw new ArgumentNullException(nameof(repositorioGenerico));
            _repositorioCentroVenta = repositorioCentroVenta ?? throw new ArgumentNullException(nameof(repositorioCentroVenta));
        }
        public async Task<bool> Handle(ValidacionFacturaQuery request, CancellationToken cancellationToken)
        {
            var centroVentas = await _repositorioCentroVenta.GetAsync(cv => cv.Nit.Equals(request.Nit));
            if(!centroVentas.Any())
                throw new ApiException() { ExceptionMessage = "Centro de venta no existe", StatusCode = HttpStatusCode.BadRequest };

            var centroVenta = centroVentas.FirstOrDefault();

            var puntosRegistrados = await _repositorioGenerico.GetAsync(p => p.Factura.Equals(request.Factura) && p.CentroVentaId == centroVenta.Id);

            return puntosRegistrados.Any();
        }
    }
}
