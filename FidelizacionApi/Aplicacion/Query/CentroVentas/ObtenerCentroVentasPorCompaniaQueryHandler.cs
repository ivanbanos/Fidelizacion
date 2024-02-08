using Aplicacion.Query.CentroVentas.Dtos;
using AutoMapper;
using Datos.Common;
using Dominio.Common.Enum;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Query.CentroVentas
{
    public class ObtenerCentroVentasPorCompaniaQueryHandler : IRequestHandler<ObtenerCentroVentasPorCompaniaQuery, IEnumerable<CentroVentaDto>>
    {
        private readonly ILogger<ObtenerCentroVentasPorCompaniaQueryHandler> _logger;
        private readonly IRepositorioGenerico<CentroVenta> _repositorioGenerico;
        private readonly IMapper _mapper;

        public ObtenerCentroVentasPorCompaniaQueryHandler(ILogger<ObtenerCentroVentasPorCompaniaQueryHandler> logger, 
                                                        IRepositorioGenerico<CentroVenta> repositorioGenerico,
                                                        IMapper mapper)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CentroVentaDto>> Handle(ObtenerCentroVentasPorCompaniaQuery request, CancellationToken cancellationToken)
        {
            var centroVentas = await _repositorioGenerico.GetAsync(cv => cv.EstadoId == (int)EstadoEnum.Activo && cv.CompaniaId == request.Id);
            return _mapper.Map<IEnumerable<CentroVentaDto>>(centroVentas);

        }
    }
}
