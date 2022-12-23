using Aplicacion.Extension;
using Datos.Common;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Command.Contrasena
{
    public class ActualizarContrasenaCommandHandler : IRequestHandler<ActualizarContrasenaCommand, bool>
    {
        private readonly ILogger<ActualizarContrasenaCommandHandler> _logger;
        private readonly IRepositorioGenerico<Usuario> _repositorioGenerico;
        private readonly IRepositorioGenerico<Fidelizado> _repositorioGenericoFidelizado;

        public ActualizarContrasenaCommandHandler(ILogger<ActualizarContrasenaCommandHandler> logger, IRepositorioGenerico<Usuario> repositorioGenerico, IRepositorioGenerico<Fidelizado> repositorioGenericoFidelizado)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repositorioGenerico = repositorioGenerico ?? throw new ArgumentNullException(nameof(repositorioGenerico));
            _repositorioGenericoFidelizado = repositorioGenericoFidelizado ?? throw new ArgumentNullException(nameof(repositorioGenericoFidelizado));
        }

        public async Task<bool> Handle(ActualizarContrasenaCommand request, CancellationToken cancellationToken)
        {
            var usuarios = await _repositorioGenerico.GetAsync(u => u.Guid.Equals(request.Usuario));
            if (usuarios.Any())
            {
                var usuario = usuarios.FirstOrDefault();
                if (usuario == null)
                    return false;

                usuario.Contrasena = request.Contrasena.Hash();
                await _repositorioGenerico.UpdateAsync(usuario);
                return true;
            }

            var fidelizados = await _repositorioGenericoFidelizado.GetAsync(f => f.Guid.Equals(request.Usuario));

            if (fidelizados == null)
                return false;

            var fidelizado = fidelizados.FirstOrDefault();
            if (fidelizado == null)
                return false;

            fidelizado.Contrasena = request.Contrasena.Hash();
            await _repositorioGenericoFidelizado.UpdateAsync(fidelizado);

            return true;
        }
    }
}
