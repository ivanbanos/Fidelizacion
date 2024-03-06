using Aplicacion.Query.Companias.Dtos;
using MediatR;

namespace Aplicacion.Query.Companias
{
    public class ObtenerCompaniaQuery : IRequest<CompaniaDto>
    {
        public int Id { get; }

        public ObtenerCompaniaQuery(int id)
        {
            Id = id;
        }
    }
}
