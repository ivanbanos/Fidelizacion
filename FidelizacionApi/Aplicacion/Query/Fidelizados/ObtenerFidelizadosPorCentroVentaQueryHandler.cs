using Datos.Common;
using Dominio.Common.Enum;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Query.Fidelizados
{
    public class ObtenerFidelizadosPorCentroVentaQueryHandler : IRequestHandler<ObtenerFidelizadosPorCentroVentaQuery, IEnumerable<Fidelizado>>
    {
        private readonly ILogger<ObtenerFidelizadosPorCentroVentaQueryHandler> _logger;
        private readonly IRepositorioGenerico<Fidelizado> _repositorioGenerico;

        public ObtenerFidelizadosPorCentroVentaQueryHandler(ILogger<ObtenerFidelizadosPorCentroVentaQueryHandler> logger, IRepositorioGenerico<Fidelizado> repositorioGenerico)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
        }

        public Task<IEnumerable<Fidelizado>> Handle(ObtenerFidelizadosPorCentroVentaQuery request, CancellationToken cancellationToken)
        {
            return _repositorioGenerico.GetAsync(f => f.EstadoId == (int)EstadoEnum.Activo && f.CentroVentaId == request.Id, includeProperties: "InformacionAdicional,InformacionAdicional.Ciudad");

        }
    }
}
