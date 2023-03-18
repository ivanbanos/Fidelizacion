using Datos.Common;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Query.Fidelizados
{
    public class ObtenerFidelizadoHandler : IRequestHandler<ObtenerFidelizadoQuery, Fidelizado>
    {
        private readonly ILogger<ObtenerFidelizadoHandler> _logger;
        private readonly IRepositorioGenerico<Fidelizado> _repositorioGenerico;

        public ObtenerFidelizadoHandler(ILogger<ObtenerFidelizadoHandler> logger, IRepositorioGenerico<Fidelizado> repositorioGenerico)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
        }

        public Task<Fidelizado> Handle(ObtenerFidelizadoQuery request, CancellationToken cancellationToken)
        {
            return _repositorioGenerico.GetByIdAsync(request.Id);

        }
    }
}
