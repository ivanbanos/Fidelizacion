using Dominio.Entidades;
using MediatR;

namespace Aplicacion.Query.CentroVentas
{
    public class ObtenerCentroVentasPorCompaniaQuery : IRequest<IEnumerable<CentroVenta>>
    {
        public int Id { get; }

        public ObtenerCentroVentasPorCompaniaQuery(int id)
        {
            Id = id;
        }
    }
}
