using Dominio.Entidades;
using MediatR;

namespace Aplicacion.Query.Fidelizados
{
    public class ObtenerFidelizadosPorCentroVentaQuery : IRequest<IEnumerable<Fidelizado>>
    {
        public int Id { get; }

        public ObtenerFidelizadosPorCentroVentaQuery(int id)
        {
            Id = id;
        }
    }
}
