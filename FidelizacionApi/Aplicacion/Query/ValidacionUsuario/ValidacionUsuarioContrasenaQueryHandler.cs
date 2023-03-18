using Aplicacion.Authtentication;
using Aplicacion.Exepciones;
using Aplicacion.Extension;
using Datos.Common;
using Dominio.Autenticacion;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Query.ValidacionUsuario
{
    public class ValidacionUsuarioContrasenaQueryHandler : IRequestHandler<ValidacionUsuarioContrasenaQuery, AuthenticationInfo>
    {
        private readonly ILogger<ValidacionUsuarioContrasenaQueryHandler> _logger;
        private readonly IRepositorioGenerico<Usuario> _repositorioGenerico;
        private readonly IAuthentication _authentication;

        public ValidacionUsuarioContrasenaQueryHandler(ILogger<ValidacionUsuarioContrasenaQueryHandler> logger, IRepositorioGenerico<Usuario> repositorioGenerico, IAuthentication authentication)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repositorioGenerico = repositorioGenerico ?? throw new ArgumentNullException(nameof(repositorioGenerico));
            _authentication = authentication ?? throw new ArgumentNullException(nameof(authentication));
        }

        public async Task<AuthenticationInfo> Handle(ValidacionUsuarioContrasenaQuery request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.NombreUsuario) || string.IsNullOrEmpty(request.Contrasena))
            {
                throw new ApiException() { ExceptionMessage = "", StatusCode = HttpStatusCode.BadRequest };
            }
            var usuarios = await _repositorioGenerico.GetAsync(u => u.NombreUsuario.Equals(request.NombreUsuario), includeProperties: "CentroVenta");
            var usuario = usuarios.FirstOrDefault();

            if (usuario != null && request.Contrasena.VerifyHash(usuario.Contrasena))
            {
                return new AuthenticationInfo() { Token = _authentication.GenerateToken(usuario), Perfil = usuario.PerfilId, IdUsuario = usuario.Guid.Value, IdCentroVenta = usuario.CentroVentaId.HasValue ? usuario.CentroVentaId.Value : 0, IdCompania = usuario.CentroVentaId.HasValue ? usuario.CentroVenta.CompaniaId : 0 };
            }
            else
            {
                throw new ApiException() { ExceptionMessage = "", StatusCode = HttpStatusCode.Forbidden };
            }
        }
    }
}
