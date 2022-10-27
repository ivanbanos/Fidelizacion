using Dominio.Entidades;
using MediatR;

namespace Aplicacion.Command.Fidelizados
{
    public class AgregarFidelizadoCommand : IRequest<bool>
    {
        public Fidelizado Fidelizado { get; }

        public AgregarFidelizadoCommand(Fidelizado fidelizado)
        {
            Fidelizado = fidelizado;
        }
    }
}
