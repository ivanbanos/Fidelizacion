﻿using Aplicacion.Exepciones;
using Datos.Common;
using Dominio.Common.Enum;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Aplicacion.Command.Usuarios
{
    public class EliminarUsuarioCommandHandler : IRequestHandler<EliminarUsuarioCommand, bool>
    {
        private readonly ILogger<EliminarUsuarioCommandHandler> _logger;
        private readonly IRepositorioGenerico<Usuario> _repositorioGenerico;

        public EliminarUsuarioCommandHandler(ILogger<EliminarUsuarioCommandHandler> logger, IRepositorioGenerico<Usuario> repositorioGenerico)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repositorioGenerico = repositorioGenerico ?? throw new ArgumentNullException(nameof(repositorioGenerico));
        }

        public async Task<bool> Handle(EliminarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuarios = await _repositorioGenerico.GetAsync(u => u.Guid.Equals(request.Usuario));
            if (usuarios == null)
                throw new ApiException() { ExceptionMessage = "Usuario no existe", StatusCode = HttpStatusCode.BadRequest };

            var usuario = usuarios.FirstOrDefault();

            usuario.EstadoId = (int)EstadoEnum.Inactivo;
            await _repositorioGenerico.UpdateAsync(usuario);

            return true;
        }
    }
}
