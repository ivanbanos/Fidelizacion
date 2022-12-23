using Dominio.Entidades;
using MediatR;

namespace Aplicacion.Command.Contrasena
{
    public class ActualizarContrasenaCommand : IRequest<bool>
    {
        public Guid Usuario { get; }
        public string Contrasena { get; }

        public ActualizarContrasenaCommand(Guid usuario, string contrasena)
        {
            Usuario = usuario;
            Contrasena = contrasena;
        }
    }
}