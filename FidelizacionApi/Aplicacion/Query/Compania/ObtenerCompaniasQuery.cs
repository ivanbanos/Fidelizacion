using MediatR;

namespace Aplicacion.Query.Compania
{
    public class ObtenerCompaniasQuery : IRequest<IEnumerable<Dominio.Entidades.Compania>>
    {
        public ObtenerCompaniasQuery()
        {
        }
    }
}
