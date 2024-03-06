using Aplicacion.Query.CentroVentas.Dtos;
using MediatR;

namespace Aplicacion.Query.CentroVentas
{
    public class ObtenerCentroVentasPorCompaniaQuery : IRequest<IEnumerable<CentroVentaDto>>
    {
        public int Id { get; }

        public ObtenerCentroVentasPorCompaniaQuery(int id)
        {
            Id = id;
        }
    }
}
