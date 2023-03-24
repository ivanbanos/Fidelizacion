using Aplicacion.Exepciones;
using Aplicacion.Extension;
using Datos.Common;
using Dominio.Common.Enum;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

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
            var usuario = await _repositorioGenerico.GetAsync(u => u.NombreUsuario.Equals(request.Usuario.NombreUsuario) 
                                                                    && u.CentroVentaId == request.Usuario.CentroVentaId);
            if(usuario.Any())
                throw new ApiException() { ExceptionMessage = "Nombre de usuario ya existe", StatusCode = HttpStatusCode.BadRequest };

            request.Usuario.EstadoId = (int)EstadoEnum.Activo;
            request.Usuario.Contrasena = request.Usuario.NombreUsuario.Hash();

            await _repositorioGenerico.AddAsync(request.Usuario);
            return true;
        }
    }
}
