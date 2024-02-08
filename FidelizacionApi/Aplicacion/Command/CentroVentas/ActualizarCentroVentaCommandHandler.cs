using Aplicacion.Exepciones;
using Datos.Common;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Aplicacion.Command.CentroVentas
{
    public class ActualizarCentroVentaCommandHandler : IRequestHandler<ActualizarCentroVentaCommand, bool>
    {
        private readonly ILogger<ActualizarCentroVentaCommandHandler> _logger;
        private readonly IRepositorioGenerico<CentroVenta> _repositorioGenerico;

        public ActualizarCentroVentaCommandHandler(ILogger<ActualizarCentroVentaCommandHandler> logger, IRepositorioGenerico<CentroVenta> repositorioGenerico)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
        }

        public async Task<bool> Handle(ActualizarCentroVentaCommand request, CancellationToken cancellationToken)
        {
            var centroVentas = await _repositorioGenerico.GetAsync(x => x.Id == request.Id);

            if (centroVentas == null)
                throw new ApiException() { ExceptionMessage = "Centro de venta no existe", StatusCode = HttpStatusCode.BadRequest };

            var centroVenta = centroVentas.FirstOrDefault();

            centroVenta.Nit = request.Nit;
            centroVenta.Nombre = request.Nombre;
            centroVenta.Direccion = request.Direccion;
            centroVenta.Telefono = request.Telefono;
            centroVenta.ValorPorPunto = request.ValorPorPunto;

            await _repositorioGenerico.UpdateAsync(centroVenta);
            return true;
        }
    }
}
