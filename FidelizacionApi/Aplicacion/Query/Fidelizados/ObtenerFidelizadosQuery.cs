using Dominio.Entidades;
using MediatR;

namespace Aplicacion.Query.Fidelizados
{
    public class ObtenerFidelizadosQuery : IRequest<IEnumerable<Fidelizado>>
    {
        public ObtenerFidelizadosQuery()
        {
        }
    }
}
