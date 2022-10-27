using Dominio.Entidades;
using MediatR;

namespace Aplicacion.Query.CentroVentas
{
    public class ObtenerCentroVentasQuery : IRequest<IEnumerable<CentroVenta>>
    {
        public ObtenerCentroVentasQuery()
        {
        }
    }
}
