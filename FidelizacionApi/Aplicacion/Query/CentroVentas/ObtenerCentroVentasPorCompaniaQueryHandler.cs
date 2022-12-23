using Datos.Common;
using Dominio.Common.Enum;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Query.CentroVentas
{
    public class ObtenerCentroVentasPorCompaniaQueryHandler : IRequestHandler<ObtenerCentroVentasPorCompaniaQuery, IEnumerable<CentroVenta>>
    {
        private readonly ILogger<ObtenerCentroVentasPorCompaniaQueryHandler> _logger;
        private readonly IRepositorioGenerico<CentroVenta> _repositorioGenerico;

        public ObtenerCentroVentasPorCompaniaQueryHandler(ILogger<ObtenerCentroVentasPorCompaniaQueryHandler> logger, IRepositorioGenerico<CentroVenta> repositorioGenerico)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
        }

        public Task<IEnumerable<CentroVenta>> Handle(ObtenerCentroVentasPorCompaniaQuery request, CancellationToken cancellationToken)
        {
            return _repositorioGenerico.GetAsync(cv => cv.EstadoId == (int)EstadoEnum.Activo && cv.CompaniaId == request.Id);

        }
    }
}
