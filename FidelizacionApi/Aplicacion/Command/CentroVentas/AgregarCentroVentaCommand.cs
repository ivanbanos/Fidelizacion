using Dominio.Entidades;
using MediatR;

namespace Aplicacion.Command.CentroVentas
{
    public class AgregarCentroVentaCommand : IRequest<bool>
    {
        public CentroVenta CentroVenta { get; }

        public AgregarCentroVentaCommand(CentroVenta centroVenta)
        {
            CentroVenta = centroVenta;
        }
    }
}
