using Datos.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Query.Compania
{
    public class ObtenerCompaniaQueryHandler : IRequestHandler<ObtenerCompaniaQuery, Dominio.Entidades.Compania>
    {
        private readonly ILogger<ObtenerCompaniaQueryHandler> _logger;
        private readonly IRepositorioGenerico<Dominio.Entidades.Compania> _repositorioGenerico;

        public ObtenerCompaniaQueryHandler(ILogger<ObtenerCompaniaQueryHandler> logger, IRepositorioGenerico<Dominio.Entidades.Compania> repositorioGenerico)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
        }

        public Task<Dominio.Entidades.Compania> Handle(ObtenerCompaniaQuery request, CancellationToken cancellationToken)
        {
            return _repositorioGenerico.GetByIdAsync(request.Id);

        }
    }
}
