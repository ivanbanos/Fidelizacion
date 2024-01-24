using Aplicacion.Query.Fidelizados.Dtos;
using Dominio.Entidades;
using MediatR;

namespace Aplicacion.Query.Fidelizados
{
    public class ObtenerFidelizadosQuery : IRequest<IEnumerable<FidelizadoDto>>
    {
        public ObtenerFidelizadosQuery()
        {
        }
    }
}
