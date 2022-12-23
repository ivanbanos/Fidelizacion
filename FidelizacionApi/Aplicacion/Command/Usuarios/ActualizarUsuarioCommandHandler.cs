using Aplicacion.Extension;
using Datos.Common;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var usuarios = await _repositorioGenerico.GetAsync(u => u.Guid.Equals(request.Usuario.Guid));
            if (usuarios == null)
                return false;

            var usuario = usuarios.FirstOrDefault();

            if (usuario == null)
                return false;

            usuario.PerfilId = request.Usuario.PerfilId;
            usuario.CentroVentaId = request.Usuario.CentroVentaId;
            await _repositorioGenerico.UpdateAsync(usuario);

            return true;
        }
    }
}
