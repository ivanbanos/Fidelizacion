using Datos.Common;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Command.Fidelizados
{
    public class ActualizarFidelizadoCommandHandler : IRequestHandler<ActualizarFidelizadoCommand, bool>
    {
        private readonly ILogger<ActualizarFidelizadoCommandHandler> _logger;
        private readonly IRepositorioGenerico<Fidelizado> _repositorioGenerico;

        public ActualizarFidelizadoCommandHandler(ILogger<ActualizarFidelizadoCommandHandler> logger, IRepositorioGenerico<Fidelizado> repositorioGenerico)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
        }

        public async Task<bool> Handle(ActualizarFidelizadoCommand request, CancellationToken cancellationToken)
        {
            var fidelizado = await _repositorioGenerico.GetAsync(x => x.Id == request.Id);

            if (fidelizado == null)
                return false;

            await _repositorioGenerico.UpdateAsync(request.Fidelizado);
            return true;
        }
    }
}
