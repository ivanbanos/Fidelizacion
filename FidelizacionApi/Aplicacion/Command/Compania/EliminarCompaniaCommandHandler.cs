using Datos.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Command.Compania
{
    public class EliminarCompaniaCommandHandler : IRequestHandler<EliminarCompaniaCommand, bool>
    {
        private readonly ILogger<EliminarCompaniaCommandHandler> _logger;
        private readonly IRepositorioGenerico<Dominio.Entidades.Compania> _repositorioGenerico;

        public EliminarCompaniaCommandHandler(ILogger<EliminarCompaniaCommandHandler> logger, IRepositorioGenerico<Dominio.Entidades.Compania> repositorioGenerico)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
        }

        public async Task<bool> Handle(EliminarCompaniaCommand request, CancellationToken cancellationToken)
        {
            var compania = await _repositorioGenerico.GetByIdAsync(request.Id);

            if (compania == null) 
                return false;

            await _repositorioGenerico.DeleteAsync(compania);
            return true;
        }
    }
}
