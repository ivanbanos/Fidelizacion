using Dominio.Entidades;
using MediatR;

namespace Aplicacion.Command.Fidelizados
{
    public class ActualizarFidelizadoCommand : IRequest<bool>
    {
        public int Id { get; }
        public Fidelizado Fidelizado { get; }

        public ActualizarFidelizadoCommand(int id, Fidelizado fidelizado)
        {
            Id = id;
            Fidelizado = fidelizado;
        }
    }
}
