using Aplicacion.Exepciones;
using Datos.Common;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Aplicacion.Command.Premios
{
    public class ActualizarPremioCommandHandler : IRequestHandler<ActualizarPremioCommand, bool>
    {
        private readonly ILogger<ActualizarPremioCommandHandler> _logger;
        private readonly IRepositorioGenerico<Premio> _repositorioPremio;

        public ActualizarPremioCommandHandler(ILogger<ActualizarPremioCommandHandler> logger, IRepositorioGenerico<Premio> repositorioPremio)
        {
            _logger = logger;
            _repositorioPremio = repositorioPremio;
        }
        public async Task<bool> Handle(ActualizarPremioCommand request, CancellationToken cancellationToken)
        {
            var premios = await _repositorioPremio.GetAsync(p => p.Guid == request.Guid);
            if(!premios.Any())
                throw new ApiException() { ExceptionMessage = "Premio no existe", StatusCode = HttpStatusCode.BadRequest };

            var premio = premios.FirstOrDefault();

            premio.Nombre = request.Nombre;
            premio.Puntos = request.Puntos;
            premio.Precio = request.Precio;
            premio.FechaFin = request.FechaFin;
            premio.CentroVentaId = request.CentroVentaId;

            await _repositorioPremio.UpdateAsync(premio);

            return true;

        }
    }
}
