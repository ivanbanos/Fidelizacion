using Dominio.Entidades;
using MediatR;

namespace Aplicacion.Command.Fidelizados
{
    public class EliminarFidelizadoCommand : IRequest<bool>
    {
        public int Id { get; }

        public EliminarFidelizadoCommand(int id)
        {
            Id = id;
        }
    }
}
