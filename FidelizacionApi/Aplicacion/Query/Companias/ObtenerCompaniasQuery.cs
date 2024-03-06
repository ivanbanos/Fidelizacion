using Aplicacion.Query.Companias.Dtos;
using MediatR;

namespace Aplicacion.Query.Companias
{
    public class ObtenerCompaniasQuery : IRequest<IEnumerable<CompaniaDto>>
    {
        public ObtenerCompaniasQuery()
        {
        }
    }
}
