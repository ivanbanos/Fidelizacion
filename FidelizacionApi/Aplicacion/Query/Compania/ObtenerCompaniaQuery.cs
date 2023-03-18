using MediatR;

namespace Aplicacion.Query.Compania
{
    public class ObtenerCompaniaQuery : IRequest<Dominio.Entidades.Compania>
    {
        public int Id { get; }

        public ObtenerCompaniaQuery(int id)
        {
            Id = id;
        }
    }
}
