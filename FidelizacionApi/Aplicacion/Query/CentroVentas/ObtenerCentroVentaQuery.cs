using Aplicacion.Query.CentroVentas.Dtos;
using MediatR;

namespace Aplicacion.Query.CentroVentas
{
    public class ObtenerCentroVentaQuery : IRequest<CentroVentaDto>
    {
        public int Id { get; }

        public ObtenerCentroVentaQuery(int id)
        {
            Id = id;
        }
    }
}
