using Dominio.Entidades;
using MediatR;

namespace Aplicacion.Command.Usuarios
{
    public class CrearUsuarioCommand : IRequest<bool>
    {
        public Usuario Usuario { get; }

        public CrearUsuarioCommand(Usuario usuario)
        {
            Usuario = usuario;
        }
    }
}
