using Dominio.Entidades;
using MediatR;

namespace Aplicacion.Command.Usuarios
{
    public class ActualizarUsuarioCommand : IRequest<bool>
    {
        public Usuario Usuario { get; }

        public ActualizarUsuarioCommand(Usuario usuario)
        {
            Usuario = usuario;
        }
    }
}