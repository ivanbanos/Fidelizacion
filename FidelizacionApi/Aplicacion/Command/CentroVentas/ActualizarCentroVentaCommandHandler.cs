using Datos.Common;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

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
            var centroVenta = await _repositorioGenerico.GetAsync(x => x.Id == request.CentroVenta.Id);

            if (centroVenta == null)
                return false;

            await _repositorioGenerico.UpdateAsync(request.CentroVenta);
            return true;
        }
    }
}
