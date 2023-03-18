using MediatR;

namespace Aplicacion.Query.Usuarios
{
    public class ObtenerUsuariosPorCentroVentaQuery : IRequest<IEnumerable<Dominio.Entidades.Usuario>>
    {
        public int Id { get; }

        public ObtenerUsuariosPorCentroVentaQuery(int id)
        {
            Id = id;
        }
    }
}
