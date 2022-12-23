using Datos.Common;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Query.Configuraciones
{
    public class ObtenerPerfilesQueryHandler : IRequestHandler<ObtenerPerfilesQuery, IEnumerable<Perfil>>
    {
        private readonly ILogger<ObtenerPerfilesQueryHandler> _logger;
        private readonly IRepositorioGenerico<Perfil> _repositorioGenerico;

        public ObtenerPerfilesQueryHandler(ILogger<ObtenerPerfilesQueryHandler> logger, IRepositorioGenerico<Perfil> repositorioGenerico)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
        }

        public Task<IEnumerable<Perfil>> Handle(ObtenerPerfilesQuery request, CancellationToken cancellationToken)
        {
            return _repositorioGenerico.GetAsync();
        }
    }
}
