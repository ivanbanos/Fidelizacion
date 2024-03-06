using Aplicacion.Exepciones;
using Datos.Common;
using Dominio.Common.Enum;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Aplicacion.Command.Fidelizados
{
    public class EliminarFidelizadoCommandHandler : IRequestHandler<EliminarFidelizadoCommand, bool>
    {
        private readonly ILogger<EliminarFidelizadoCommandHandler> _logger;
        private readonly IRepositorioGenerico<Fidelizado> _repositorioGenerico;

        public EliminarFidelizadoCommandHandler(ILogger<EliminarFidelizadoCommandHandler> logger, IRepositorioGenerico<Fidelizado> repositorioGenerico)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
        }

        public async Task<bool> Handle(EliminarFidelizadoCommand request, CancellationToken cancellationToken)
        {
            var fidelizado = await _repositorioGenerico.GetByIdAsync(request.Id);

            if (fidelizado == null)
                throw new ApiException() { ExceptionMessage = "Fidelizado no existe", StatusCode = HttpStatusCode.BadRequest };

            fidelizado.EstadoId = (int)EstadoEnum.Inactivo;
            await _repositorioGenerico.UpdateAsync(fidelizado);
            return true;
        }
    }
}
