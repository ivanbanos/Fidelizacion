using Datos.Common;
using Dominio.Common.Enum;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Query.Fidelizados
{
    public class ObtenerFidelizadosQueryHandler : IRequestHandler<ObtenerFidelizadosQuery, IEnumerable<Fidelizado>>
    {
        private readonly ILogger<ObtenerFidelizadosQueryHandler> _logger;
        private readonly IRepositorioGenerico<Fidelizado> _repositorioGenerico;

        public ObtenerFidelizadosQueryHandler(ILogger<ObtenerFidelizadosQueryHandler> logger, IRepositorioGenerico<Fidelizado> repositorioGenerico)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
        }

        public Task<IEnumerable<Fidelizado>> Handle(ObtenerFidelizadosQuery request, CancellationToken cancellationToken)
        {
            return _repositorioGenerico.GetAsync(f => f.EstadoId == (int)EstadoEnum.Activo, includeProperties: "InformacionAdicional,InformacionAdicional.Ciudad");

        }
    }
}
