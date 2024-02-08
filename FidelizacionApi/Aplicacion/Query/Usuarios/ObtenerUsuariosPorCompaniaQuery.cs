using Aplicacion.Query.Usuarios.Dtos;
using MediatR;

namespace Aplicacion.Query.Usuarios
{
    public class ObtenerUsuariosPorCompaniaQuery : IRequest<IEnumerable<UsuarioDTO>>
    {
        public int Id { get; }

        public ObtenerUsuariosPorCompaniaQuery(int id)
        {
            Id = id;
        }
    }
}
