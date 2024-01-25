using Aplicacion.Query.Fidelizados.Dtos;
using MediatR;

namespace Aplicacion.Query.Fidelizados
{
    public class ObtenerFidelizadosQuery : IRequest<IEnumerable<FidelizadoDto>>
    {
        public string? Filtro { get; }
        public ObtenerFidelizadosQuery(string? filtro)
        {
            Filtro = filtro;
        }
    }
}
