using Dominio.Entidades;
using MediatR;

namespace Aplicacion.Query.Configuraciones
{
    public class ObtenerPerfilesQuery : IRequest<IEnumerable<Perfil>>
    {
        public ObtenerPerfilesQuery()
        {
        }
    }
}
