using Aplicacion.Exepciones;
using Datos.Common;
using Dominio.Common.Enum;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Aplicacion.Command.Premios
{
    public class EliminarPremioCommandHandler : IRequestHandler<EliminarPremioCommand, bool>
    {
        private readonly ILogger<EliminarPremioCommandHandler> _logger;
        private readonly IRepositorioGenerico<Premio> _repositorioPremio;

        public EliminarPremioCommandHandler(ILogger<EliminarPremioCommandHandler> logger, IRepositorioGenerico<Premio> repositorioPremio)
        {
            _logger = logger;
            _repositorioPremio = repositorioPremio;
        }

        public async Task<bool> Handle(EliminarPremioCommand request, CancellationToken cancellationToken)
        {
            var premios = await _repositorioPremio.GetAsync(p => p.Guid == request.Guid);
            if (!premios.Any())
                throw new ApiException() { ExceptionMessage = "Premio no existe", StatusCode = HttpStatusCode.BadRequest };

            var premio = premios.FirstOrDefault();

            premio.EstadoId = (int)EstadoEnum.Inactivo;

            await _repositorioPremio.UpdateAsync(premio);

            return true;
        }
    }
}
