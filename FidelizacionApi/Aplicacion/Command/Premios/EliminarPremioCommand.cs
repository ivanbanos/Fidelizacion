using MediatR;

namespace Aplicacion.Command.Premios
{
    public class EliminarPremioCommand : IRequest<bool>
    {
        public Guid Guid { get; set; }

        public EliminarPremioCommand(Guid guid)
        {
            Guid = guid;
        }
    }
}
