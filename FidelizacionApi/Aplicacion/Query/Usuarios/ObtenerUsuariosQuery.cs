using MediatR;

namespace Aplicacion.Query.Usuarios
{
    public class ObtenerUsuariosQuery : IRequest<IEnumerable<Dominio.Entidades.Usuario>>
    {
        public ObtenerUsuariosQuery()
        {
        }
    }
}
