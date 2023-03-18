using Dominio.Autenticacion;
using MediatR;

namespace Aplicacion.Query.ValidacionUsuario
{
    public class ValidacionUsuarioContrasenaQuery : IRequest<AuthenticationInfo>
    {
        public ValidacionUsuarioContrasenaQuery(string nombreUsuario, string contrasena)
        {
            NombreUsuario = nombreUsuario;
            Contrasena = contrasena;
        }

        public string NombreUsuario { get; }
        public string Contrasena { get; }
    }
}
