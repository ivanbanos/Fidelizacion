using Dominio.Entidades;
using MediatR;

namespace Aplicacion.Command.CentroVentas
{
    public class ActualizarCentroVentaCommand : IRequest<bool>
    {
        public int Id { get; }
        public CentroVenta CentroVenta { get; }

        public ActualizarCentroVentaCommand(int id, CentroVenta centroVenta)
        {
            Id = id;
            CentroVenta = centroVenta;
        }
    }
}
