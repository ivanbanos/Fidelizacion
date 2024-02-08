using Aplicacion.Query.Fidelizados.Dtos;
using MediatR;

namespace Aplicacion.Query.Fidelizados
{
    public class ObtenerFidelizadosPorCentroVentaYDocumentoQuery : IRequest<IEnumerable<FidelizadoDto>>
    {
        public ObtenerFidelizadosPorCentroVentaYDocumentoQuery(int id, string documento)
        {
            Id = id;
            Documento = documento;
        }

        public int Id { get; }
        public string Documento { get; }
    }
}
