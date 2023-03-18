using Dominio.Entidades;
using MediatR;

namespace Aplicacion.Query.CentroVentas
{
    public class ObtenerCentroVentaQuery : IRequest<CentroVenta>
    {
        public int Id { get; }

        public ObtenerCentroVentaQuery(int id)
        {
            Id = id;
        }
    }
}
