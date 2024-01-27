using Aplicacion.Query.Fidelizados.Dtos;
using AutoMapper;
using Datos.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Query.Fidelizados
{
    public class ObtenerFidelizadosPorCentroVentaQueryHandler : IRequestHandler<ObtenerFidelizadosPorCentroVentaQuery, IEnumerable<FidelizadoDto>>
    {
        private readonly ILogger<ObtenerFidelizadosPorCentroVentaQueryHandler> _logger;
        private readonly IRepositorioGenerico<Dominio.Dtos.FidelizadoDto> _repositorioGenerico;
        private readonly IMapper _mapper;

        public ObtenerFidelizadosPorCentroVentaQueryHandler(ILogger<ObtenerFidelizadosPorCentroVentaQueryHandler> logger, IRepositorioGenerico<Dominio.Dtos.FidelizadoDto> repositorioGenerico, IMapper mapper)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FidelizadoDto>> Handle(ObtenerFidelizadosPorCentroVentaQuery request, CancellationToken cancellationToken)
        {
            var parameter = new Dictionary<string, object>
            {
                {"CentroVentaId",  request.Id},
                {"Filtro", "'"+request.Filtro+"'" ?? "''" }
            };
            var fidelizados = await _repositorioGenerico.ExecuteStoredProcedure("SPObtenerFidelizadosPorCentroVenta", parameter);
            return _mapper.Map<IEnumerable<FidelizadoDto>>(fidelizados);

        }
    }
}
