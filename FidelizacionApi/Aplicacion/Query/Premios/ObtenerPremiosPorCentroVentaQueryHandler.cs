using Aplicacion.Exepciones;
using Aplicacion.Query.Premios.Dtos;
using AutoMapper;
using Datos.Common;
using Dominio.Common.Enum;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Aplicacion.Query.Premios
{
    public class ObtenerPremiosPorCentroVentaQueryHandler : IRequestHandler<ObtenerPremiosPorCentroVentaQuery, IEnumerable<PremioDTO>>
    {
        private readonly ILogger<ObtenerPremiosPorCentroVentaQueryHandler> _logger;
        private readonly IRepositorioGenerico<Premio> _repositorioPremio;
        private readonly IRepositorioGenerico<CentroVenta> _repositorioCentroDeVenta;
        private readonly IMapper _mapper;

        public ObtenerPremiosPorCentroVentaQueryHandler(ILogger<ObtenerPremiosPorCentroVentaQueryHandler> logger, IRepositorioGenerico<Premio> repositorioPremio, IRepositorioGenerico<CentroVenta> repositorioCentroDeVenta, IMapper mapper)
        {
            _logger = logger;
            _repositorioPremio = repositorioPremio;
            _repositorioCentroDeVenta = repositorioCentroDeVenta;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PremioDTO>> Handle(ObtenerPremiosPorCentroVentaQuery request, CancellationToken cancellationToken)
        {
            var centroDeVentas = await _repositorioCentroDeVenta.GetAsync(cv => cv.Id == request.CentroDeVentaId, includeProperties: "Compania");
            if(!centroDeVentas.Any())
                throw new ApiException() { ExceptionMessage = "Centro de venta no existe", StatusCode = HttpStatusCode.BadRequest };

            var centroDeVenta = centroDeVentas.FirstOrDefault();

            var premios = await _repositorioPremio.GetAsync(p => p.EstadoId == (int)EstadoEnum.Activo && centroDeVenta.Id == p.CentroVentaId && p.FechaFin >= DateTime.Now);
            return _mapper.Map<IEnumerable<PremioDTO>>(premios);
        }
    }
}
