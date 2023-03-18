using MediatR;

namespace Aplicacion.Command.Compania
{
    public class EliminarCompaniaCommand : IRequest<bool>
    {
        public int Id { get; }

        public EliminarCompaniaCommand(int id)
        {
            Id = id;
        }
    }
}
