using Aplicacion.Query.Usuarios.Dtos;
using MediatR;

namespace Aplicacion.Query.Usuarios
{
    public class ObtenerUsuariosQuery : IRequest<IEnumerable<UsuarioDTO>>
    {
        public ObtenerUsuariosQuery()
        {
        }
    }
}
