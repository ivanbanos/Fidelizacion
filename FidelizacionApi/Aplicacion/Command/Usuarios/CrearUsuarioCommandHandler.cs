using Aplicacion.Extension;
using Datos.Common;
using Dominio.Common.Enum;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Command.Usuarios
{
    public class CrearUsuarioCommandHandler : IRequestHandler<CrearUsuarioCommand, bool>
    {
        private readonly ILogger<CrearUsuarioCommandHandler> _logger;
        private readonly IRepositorioGenerico<Usuario> _repositorioGenerico;

        public CrearUsuarioCommandHandler(ILogger<CrearUsuarioCommandHandler> logger, IRepositorioGenerico<Usuario> repositorioGenerico)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repositorioGenerico = repositorioGenerico ?? throw new ArgumentNullException(nameof(repositorioGenerico));
        }

        public async Task<bool> Handle(CrearUsuarioCommand request, CancellationToken cancellationToken)
        {
            {
                request.Usuario.EstadoId = (int)EstadoEnum.Activo;
                request.Usuario.Contrasena = request.Usuario.NombreUsuario.Hash();

                await _repositorioGenerico.AddAsync(request.Usuario);
                return true;
            }
        }
    }
}
