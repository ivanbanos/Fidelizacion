using MediatR;

namespace Aplicacion.Command.Compania
{
    public class AgregarCompaniaCommand : IRequest<bool>
    {
        public Dominio.Entidades.Compania Compania { get; }

        public AgregarCompaniaCommand(Dominio.Entidades.Compania compania)
        {
            Compania = compania;
        }
    }
}
