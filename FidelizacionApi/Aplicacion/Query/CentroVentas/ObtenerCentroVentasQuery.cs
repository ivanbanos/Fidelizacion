using Aplicacion.Query.CentroVentas.Dtos;
using MediatR;

namespace Aplicacion.Query.CentroVentas
{
    public class ObtenerCentroVentasQuery : IRequest<IEnumerable<CentroVentaDto>>
    {
        public ObtenerCentroVentasQuery()
        {
        }
    }
}
