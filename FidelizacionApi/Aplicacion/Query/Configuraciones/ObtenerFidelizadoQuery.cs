using Dominio.Entidades;
using MediatR;

namespace Aplicacion.Query.Configuraciones
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
