using Aplicacion.Query.Premios.Dtos;
using MediatR;

namespace Aplicacion.Query.Premios
{
    public class ObtenerPremiosVigentesQuery : IRequest<IEnumerable<PremioDTO>>
    {
        public int CentroDeVentaId { get; set; }

        public ObtenerPremiosVigentesQuery(int centroDeVentaId)
        {
            CentroDeVentaId = centroDeVentaId;
        }
    }
}
