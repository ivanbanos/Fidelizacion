using MediatR;

namespace Aplicacion.Command.Compania
{
    public class ActualizarCompaniaCommand : IRequest<bool>
    {
        public int Id { get; }
        public Dominio.Entidades.Compania Compania { get; }

        public ActualizarCompaniaCommand(int id, Dominio.Entidades.Compania compania)
        {
            Id = id;
            Compania = compania;
        }
    }
}
