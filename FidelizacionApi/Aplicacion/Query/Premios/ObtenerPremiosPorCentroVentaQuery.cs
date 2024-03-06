using Aplicacion.Query.Premios.Dtos;
using MediatR;

namespace Aplicacion.Query.Premios
{
    public class ObtenerPremiosPorCentroVentaQuery : IRequest<IEnumerable<PremioDTO>>
    {
        public int CentroDeVentaId { get; set; }

        public ObtenerPremiosPorCentroVentaQuery(int centroDeVentaId)
        {
            CentroDeVentaId = centroDeVentaId;
        }
    }
}
