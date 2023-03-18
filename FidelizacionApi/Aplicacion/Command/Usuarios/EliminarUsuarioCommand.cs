using MediatR;

namespace Aplicacion.Command.Usuarios
{
    public class EliminarUsuarioCommand : IRequest<bool>
    {
        public Guid Usuario { get; }

        public EliminarUsuarioCommand(Guid usuario)
        {
            Usuario = usuario;
        }
    }
}
