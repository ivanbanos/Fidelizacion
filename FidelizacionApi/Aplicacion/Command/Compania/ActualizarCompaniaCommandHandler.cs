using Datos.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Command.Compania
{
    public class ActualizarCompaniaCommandHandler : IRequestHandler<ActualizarCompaniaCommand, bool>
    {
        private readonly ILogger<ActualizarCompaniaCommandHandler> _logger;
        private readonly IRepositorioGenerico<Dominio.Entidades.Compania> _repositorioGenerico;

        public ActualizarCompaniaCommandHandler(ILogger<ActualizarCompaniaCommandHandler> logger, IRepositorioGenerico<Dominio.Entidades.Compania> repositorioGenerico)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
        }

        public async Task<bool> Handle(ActualizarCompaniaCommand request, CancellationToken cancellationToken)
        {
            var compania = await _repositorioGenerico.GetAsync(x => x.Id == request.Id);

            if (compania == null) 
                return false;

            await _repositorioGenerico.UpdateAsync(request.Compania);
            return true;
        }
    }
}
