using Aplicacion.Query.CentroVentas.Dtos;
using AutoMapper;
using Datos.Common;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Query.CentroVentas
{
    public class ObtenerCentroVentaHandler : IRequestHandler<ObtenerCentroVentaQuery, CentroVentaDto>
    {
        private readonly ILogger<ObtenerCentroVentaHandler> _logger;
        private readonly IRepositorioGenerico<CentroVenta> _repositorioGenerico;
        private readonly IMapper _mapper;

        public ObtenerCentroVentaHandler(ILogger<ObtenerCentroVentaHandler> logger, 
                                        IRepositorioGenerico<CentroVenta> repositorioGenerico,
                                        IMapper mapper)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
            _mapper = mapper;
        }

        public async Task<CentroVentaDto> Handle(ObtenerCentroVentaQuery request, CancellationToken cancellationToken)
        {
            var centroVenta = await _repositorioGenerico.GetByIdAsync(request.Id);
            return _mapper.Map<CentroVentaDto>(centroVenta);

        }
    }
}
