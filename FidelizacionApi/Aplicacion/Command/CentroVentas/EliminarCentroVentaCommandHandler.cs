using Datos.Common;
using Dominio.Common.Enum;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

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
                return false;

            centroVenta.EstadoId = (int)EstadoEnum.Inactivo;
            await _repositorioGenerico.UpdateAsync(centroVenta);
            return true;
        }
    }
}
