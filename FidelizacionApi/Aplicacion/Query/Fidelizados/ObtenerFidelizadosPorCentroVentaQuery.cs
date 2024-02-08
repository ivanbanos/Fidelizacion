using Aplicacion.Query.Fidelizados.Dtos;
using MediatR;

namespace Aplicacion.Query.Fidelizados
{
    public class ObtenerFidelizadosPorCentroVentaQuery : IRequest<IEnumerable<FidelizadoDto>>
    {
        public int Id { get; }
        public string? Filtro { get; } = string.Empty;

        public ObtenerFidelizadosPorCentroVentaQuery(int id, string? filtro)
        {
            Id = id;
            Filtro = filtro;
        }
    }
}
