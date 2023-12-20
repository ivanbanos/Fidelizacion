using Aplicacion.Command.Premios.Dtos;
using MediatR;

namespace Aplicacion.Command.Premios
{
    public class RedencionPremioCommand : IRequest<RespuestaRedencionPremioDTO>
    {
        public Guid PremioId { get; set; }
        public int Cantidad { get; set; }
        public string DocumentoFidelizado { get; set; }
        public int CentroDeVentaId { get; set; }
    }
}
