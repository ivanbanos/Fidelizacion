using Datos.Common;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Command.Puntos
{
    public class AgregarPuntosCommandHandler : IRequestHandler<AgregarPuntosCommand, bool>
    {
        private readonly ILogger<AgregarPuntosCommandHandler> _logger;
        private readonly IRepositorioGenerico<Punto> _repositorioGenerico;
        private readonly IRepositorioGenerico<Fidelizado> _repositorioFidelizado;
        private readonly IRepositorioGenerico<CentroVenta> _repositorioCentroVenta;
        public AgregarPuntosCommandHandler(ILogger<AgregarPuntosCommandHandler> logger, IRepositorioGenerico<Punto> repositorioGenerico, IRepositorioGenerico<Fidelizado> repositorioFidelizado, IRepositorioGenerico<CentroVenta> repositorioCentroVenta)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repositorioGenerico = repositorioGenerico ?? throw new ArgumentNullException(nameof(repositorioGenerico));
            _repositorioFidelizado = repositorioFidelizado ?? throw new ArgumentNullException(nameof(repositorioFidelizado));
            _repositorioCentroVenta = repositorioCentroVenta ?? throw new ArgumentNullException(nameof(repositorioCentroVenta));
        }

        public async Task<bool> Handle(AgregarPuntosCommand request, CancellationToken cancellationToken)
        {
            var centroVentas = await _repositorioCentroVenta.GetAsync(f => f.Nit.Equals(request.NitCentroVenta));

            if (!centroVentas.Any())
                return false;

            var centroVenta = centroVentas.FirstOrDefault();

            var fidelizados = await _repositorioFidelizado
                                       .GetAsync(f => f.Documento.Equals(request.DocumentoFidelizado)
                                                        && f.CentroVentaId == centroVenta.Id);
            if(!fidelizados.Any())
                return false;

            var fidelizado = fidelizados.FirstOrDefault();

            var facturas = await _repositorioGenerico.GetAsync(fc => fc.Factura == request.Factura && fc.CentroVentaId == centroVenta.Id);
            if(facturas.Any())
                return false;

            fidelizado.Puntos = (fidelizado.Puntos ?? 0) + (request.ValorVenta / centroVenta.ValorPorPunto);
            
            await _repositorioGenerico.AddAsync(new Punto(request.ValorVenta, request.Factura, fidelizado.Id, centroVenta.Id));
            await _repositorioFidelizado.UpdateAsync(fidelizado);
            return true;

        }
    }
}
