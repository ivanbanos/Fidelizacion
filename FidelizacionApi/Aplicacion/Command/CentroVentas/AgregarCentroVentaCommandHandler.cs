using Datos.Common;
using Dominio.Common.Enum;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Command.CentroVentas
{
    public class AgregarCentroVentaCommandHandler : IRequestHandler<AgregarCentroVentaCommand, bool>
    {
        private readonly ILogger<AgregarCentroVentaCommandHandler> _logger;
        private readonly IRepositorioGenerico<CentroVenta> _repositorioGenerico;

        public AgregarCentroVentaCommandHandler(ILogger<AgregarCentroVentaCommandHandler> logger, IRepositorioGenerico<CentroVenta> repositorioGenerico)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
        }

        public async Task<bool> Handle(AgregarCentroVentaCommand request, CancellationToken cancellationToken)
        {
            request.CentroVenta.EstadoId = (int)EstadoEnum.Activo;
            await _repositorioGenerico.AddAsync(request.CentroVenta);
            return true;
        }
    }
}
