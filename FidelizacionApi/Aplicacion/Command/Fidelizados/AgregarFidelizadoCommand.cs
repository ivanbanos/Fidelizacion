using Dominio.Entidades;
using MediatR;

namespace Aplicacion.Command.Fidelizados
{
    public class AgregarFidelizadoCommand : IRequest<bool>
    {
        public Fidelizado Fidelizado { get; }
        public Guid Usuario { get; }

        public AgregarFidelizadoCommand(Fidelizado fidelizado, Guid usuario)
        {
            Fidelizado = fidelizado;
            Usuario = usuario;
        }
    }
}
