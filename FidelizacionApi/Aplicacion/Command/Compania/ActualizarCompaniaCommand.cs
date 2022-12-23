using MediatR;

namespace Aplicacion.Command.Compania
{
    public class ActualizarCompaniaCommand : IRequest<bool>
    {
        public Dominio.Entidades.Compania Compania { get; }

        public ActualizarCompaniaCommand(Dominio.Entidades.Compania compania)
        {
            Compania = compania;
        }
    }
}
