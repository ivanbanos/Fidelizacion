using Aplicacion.Query.Fidelizados.Dtos;
using MediatR;

namespace Aplicacion.Query.Fidelizados
{
    public class ObtenerFidelizadosPorCentroVentaQuery : IRequest<IEnumerable<FidelizadoDto>>
    {
        public int Id { get; }

        public ObtenerFidelizadosPorCentroVentaQuery(int id)
        {
            Id = id;
        }
    }
}
