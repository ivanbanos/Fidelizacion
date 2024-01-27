using Aplicacion.Query.Fidelizados.Dtos;
using MediatR;

namespace Aplicacion.Query.Fidelizados
{
    public class ObtenerFidelizadoQuery : IRequest<FidelizadoDto>
    {
        public int Id { get; }

        public ObtenerFidelizadoQuery(int id)
        {
            Id = id;
        }
    }
}
