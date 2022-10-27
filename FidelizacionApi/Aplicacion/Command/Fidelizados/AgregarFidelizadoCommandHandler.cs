using Datos.Common;
using Dominio.Common.Enum;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Command.Fidelizados
{
    public class AgregarFidelizadoCommandHandler : IRequestHandler<AgregarFidelizadoCommand, bool>
    {
        private readonly ILogger<AgregarFidelizadoCommandHandler> _logger;
        private readonly IRepositorioGenerico<Fidelizado> _repositorioGenerico;

        public AgregarFidelizadoCommandHandler(ILogger<AgregarFidelizadoCommandHandler> logger, IRepositorioGenerico<Fidelizado> repositorioGenerico)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
        }

        public async Task<bool> Handle(AgregarFidelizadoCommand request, CancellationToken cancellationToken)
        {
            request.Fidelizado.EstadoId = (int)EstadoEnum.Activo;
            request.Fidelizado.FechaCreacion = DateTime.Now;
            request.Fidelizado.InformacionAdicional.UsuarioId = 1;

            await _repositorioGenerico.AddAsync(request.Fidelizado);
            return true;
        }
    }
}
