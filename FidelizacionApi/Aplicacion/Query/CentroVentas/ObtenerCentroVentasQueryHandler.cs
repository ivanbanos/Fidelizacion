using Aplicacion.Query.CentroVentas.Dtos;
using AutoMapper;
using Datos.Common;
using Dominio.Common.Enum;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Query.CentroVentas
{
    public class ObtenerCentroVentasQueryHandler : IRequestHandler<ObtenerCentroVentasQuery, IEnumerable<CentroVentaDto>>
    {
        private readonly ILogger<ObtenerCentroVentasQueryHandler> _logger;
        private readonly IRepositorioGenerico<CentroVenta> _repositorioGenerico;
        private readonly IMapper _mapper;

        public ObtenerCentroVentasQueryHandler(ILogger<ObtenerCentroVentasQueryHandler> logger, 
                                                IRepositorioGenerico<CentroVenta> repositorioGenerico,
                                                IMapper mapper)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CentroVentaDto>> Handle(ObtenerCentroVentasQuery request, CancellationToken cancellationToken)
        {
            var centroVentas = await _repositorioGenerico.GetAsync(cv => cv.EstadoId == (int)EstadoEnum.Activo);
            return _mapper.Map<IEnumerable<CentroVentaDto>>(centroVentas);

        }
    }
}
