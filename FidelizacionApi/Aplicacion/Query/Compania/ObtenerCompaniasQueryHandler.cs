using Datos.Common;
using Dominio.Common.Enum;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Query.Compania
{
    public class ObtenerCompaniasQueryHandler : IRequestHandler<ObtenerCompaniasQuery, IEnumerable<Dominio.Entidades.Compania>>
    {
        private readonly ILogger<ObtenerCompaniasQueryHandler> _logger;
        private readonly IRepositorioGenerico<Dominio.Entidades.Compania> _repositorioGenerico;

        public ObtenerCompaniasQueryHandler(ILogger<ObtenerCompaniasQueryHandler> logger, IRepositorioGenerico<Dominio.Entidades.Compania> repositorioGenerico)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
        }

        public Task<IEnumerable<Dominio.Entidades.Compania>> Handle(ObtenerCompaniasQuery request, CancellationToken cancellationToken)
        {
            return _repositorioGenerico.GetAsync(c => c.EstadoId == (int)EstadoEnum.Activo);

        }
    }
}
