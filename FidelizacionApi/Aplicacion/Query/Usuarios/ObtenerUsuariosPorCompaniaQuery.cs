using MediatR;

namespace Aplicacion.Query.Usuarios
{
    public class ObtenerUsuariosPorCompaniaQuery : IRequest<IEnumerable<Dominio.Entidades.Usuario>>
    {
        public int Id { get; }

        public ObtenerUsuariosPorCompaniaQuery(int id)
        {
            Id = id;
        }
    }
}
