using Aplicacion.Exepciones;
using Datos.Common;
using Dominio.Common.Enum;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Aplicacion.Command.CentroVentas
{
    public class EliminarCentroVentaCommandHandler : IRequestHandler<EliminarCentroVentaCommand, bool>
    {
        private readonly ILogger<EliminarCentroVentaCommandHandler> _logger;
        private readonly IRepositorioGenerico<CentroVenta> _repositorioGenerico;

        public EliminarCentroVentaCommandHandler(ILogger<EliminarCentroVentaCommandHandler> logger, IRepositorioGenerico<CentroVenta> repositorioGenerico)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
        }

        public async Task<bool> Handle(EliminarCentroVentaCommand request, CancellationToken cancellationToken)
        {
            var centroVenta = await _repositorioGenerico.GetByIdAsync(request.Id);

            if (centroVenta == null)
                throw new ApiException() { ExceptionMessage = "Centro de venta no existe", StatusCode = HttpStatusCode.BadRequest };

            centroVenta.EstadoId = (int)EstadoEnum.Inactivo;
            await _repositorioGenerico.UpdateAsync(centroVenta);
            return true;
        }
    }
}
