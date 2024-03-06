using Aplicacion.Exepciones;
using Datos.Common;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Aplicacion.Command.Usuarios
{
    public class ActualizarUsuarioCommandHandler : IRequestHandler<ActualizarUsuarioCommand, bool>
    {
        private readonly ILogger<ActualizarUsuarioCommandHandler> _logger;
        private readonly IRepositorioGenerico<Usuario> _repositorioGenerico;

        public ActualizarUsuarioCommandHandler(ILogger<ActualizarUsuarioCommandHandler> logger, IRepositorioGenerico<Usuario> repositorioGenerico)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repositorioGenerico = repositorioGenerico ?? throw new ArgumentNullException(nameof(repositorioGenerico));
        }

        public async Task<bool> Handle(ActualizarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuarios = await _repositorioGenerico.GetAsync(u => u.Guid.Equals(request.Guid));
            if (usuarios == null)
                throw new ApiException() { ExceptionMessage = "Usuario no existe", StatusCode = HttpStatusCode.BadRequest };

            var usuario = usuarios.FirstOrDefault();

            usuario.PerfilId = request.PerfilId;
            usuario.CentroVentaId = request.CentroVentaId;
            await _repositorioGenerico.UpdateAsync(usuario);
            return true;
        }
    }
}
