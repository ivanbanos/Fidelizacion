using MediatR;

namespace Aplicacion.Command.CentroVentas
{
    public class EliminarCentroVentaCommand : IRequest<bool>
    {
        public int Id { get; }

        public EliminarCentroVentaCommand(int id)
        {
            Id = id;
        }
    }
}
