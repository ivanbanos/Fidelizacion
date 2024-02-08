using Aplicacion.Query.Premios.Dtos;
using MediatR;

namespace Aplicacion.Query.Premios
{
    public class ObtenerPremiosQuery : IRequest<IEnumerable<PremioDTO>>
    {
        public int CentroDeVentaId { get; set; }

        public ObtenerPremiosQuery(int centroDeVentaId)
        {
            CentroDeVentaId = centroDeVentaId;
        }
    }
}
