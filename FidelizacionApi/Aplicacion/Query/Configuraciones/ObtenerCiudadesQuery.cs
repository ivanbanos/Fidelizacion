using Dominio.Entidades;
using MediatR;

namespace Aplicacion.Query.Configuraciones
{
    public class ObtenerCiudadesQuery : IRequest<IEnumerable<Ciudad>>
    {
        public ObtenerCiudadesQuery()
        {
        }
    }
}
