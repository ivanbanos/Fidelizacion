using Aplicacion.Exepciones;
using Datos.Common;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Aplicacion.Command.Companias
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
            var companias = await _repositorioGenerico.GetAsync(x => x.Id == request.Id);

            if (companias == null)
                throw new ApiException() { ExceptionMessage = "Compañia no existe", StatusCode = HttpStatusCode.BadRequest };

            var compania = companias.FirstOrDefault();

            compania.Nombre = request.Nombre;
            compania.VigenciaPuntos = request.VigenciaPuntos;
            compania.TipoVencimientoId = request.TipoVencimientoId;

            await _repositorioGenerico.UpdateAsync(compania);
            return true;
        }
    }
}
