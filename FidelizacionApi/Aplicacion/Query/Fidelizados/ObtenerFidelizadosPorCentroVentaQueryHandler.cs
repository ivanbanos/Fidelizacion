using Aplicacion.Query.Fidelizados.Dtos;
using AutoMapper;
using Datos.Common;
using Dominio.Common.Enum;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace Aplicacion.Query.Fidelizados
{
    public class ObtenerFidelizadosPorCentroVentaQueryHandler : IRequestHandler<ObtenerFidelizadosPorCentroVentaQuery, IEnumerable<FidelizadoDto>>
    {
        private readonly ILogger<ObtenerFidelizadosPorCentroVentaQueryHandler> _logger;
        private readonly IRepositorioGenerico<Fidelizado> _repositorioGenerico;
        private readonly IMapper _mapper;

        public ObtenerFidelizadosPorCentroVentaQueryHandler(ILogger<ObtenerFidelizadosPorCentroVentaQueryHandler> logger, IRepositorioGenerico<Fidelizado> repositorioGenerico, IMapper mapper)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FidelizadoDto>> Handle(ObtenerFidelizadosPorCentroVentaQuery request, CancellationToken cancellationToken)
        {
            var fidelizados = await _repositorioGenerico.GetAsync(f => f.EstadoId == (int)EstadoEnum.Activo && f.CentroVentaId == request.Id, includeProperties: "InformacionAdicional,InformacionAdicional.Ciudad");
            return _mapper.Map<IEnumerable<FidelizadoDto>>(fidelizados);

        }
    }
}
