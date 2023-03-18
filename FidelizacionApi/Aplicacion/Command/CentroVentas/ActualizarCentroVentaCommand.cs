using Dominio.Entidades;
using MediatR;

namespace Aplicacion.Command.CentroVentas
{
    public class ActualizarCentroVentaCommand : IRequest<bool>
    {
        public CentroVenta CentroVenta { get; }

        public ActualizarCentroVentaCommand(CentroVenta centroVenta)
        {
            CentroVenta = centroVenta;
        }
    }
}
