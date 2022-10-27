using Dominio.Entidades;
using MediatR;

namespace Aplicacion.Query.Fidelizados
{
    public class ObtenerFidelizadoQuery : IRequest<Fidelizado>
    {
        public int Id { get; }

        public ObtenerFidelizadoQuery(int id)
        {
            Id = id;
        }
    }
}
