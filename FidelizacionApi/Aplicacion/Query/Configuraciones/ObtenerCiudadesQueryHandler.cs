using Datos.Common;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Query.Configuraciones
{
    public class ObtenerCiudadesQueryHandler : IRequestHandler<ObtenerCiudadesQuery, IEnumerable<Ciudad>>
    {
        private readonly ILogger<ObtenerCiudadesQueryHandler> _logger;
        private readonly IRepositorioGenerico<Ciudad> _repositorioGenerico;

        public ObtenerCiudadesQueryHandler(ILogger<ObtenerCiudadesQueryHandler> logger, IRepositorioGenerico<Ciudad> repositorioGenerico)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
        }

        public Task<IEnumerable<Ciudad>> Handle(ObtenerCiudadesQuery request, CancellationToken cancellationToken)
        {
            return _repositorioGenerico.GetAsync();
        }
    }
}
