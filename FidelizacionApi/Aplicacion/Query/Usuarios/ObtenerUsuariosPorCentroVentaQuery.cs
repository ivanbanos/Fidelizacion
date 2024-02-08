using Aplicacion.Query.Usuarios.Dtos;
using MediatR;

namespace Aplicacion.Query.Usuarios
{
    public class ObtenerUsuariosPorCentroVentaQuery : IRequest<IEnumerable<UsuarioDTO>>
    {
        public int Id { get; }

        public ObtenerUsuariosPorCentroVentaQuery(int id)
        {
            Id = id;
        }
    }
}
