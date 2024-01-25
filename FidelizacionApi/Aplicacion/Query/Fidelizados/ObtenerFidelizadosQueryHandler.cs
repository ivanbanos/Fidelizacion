using Aplicacion.Query.Fidelizados.Dtos;
using AutoMapper;
using Datos.Common;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Query.Fidelizados
{
    public class ObtenerFidelizadosQueryHandler : IRequestHandler<ObtenerFidelizadosQuery, IEnumerable<FidelizadoDto>>
    {
        private readonly ILogger<ObtenerFidelizadosQueryHandler> _logger;
        private readonly IRepositorioGenerico<Dominio.Dtos.FidelizadoDto> _repositorioGenerico;
        private readonly IMapper _mapper;

        public ObtenerFidelizadosQueryHandler(ILogger<ObtenerFidelizadosQueryHandler> logger, IRepositorioGenerico<Dominio.Dtos.FidelizadoDto> repositorioGenerico, IMapper mapper)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FidelizadoDto>> Handle(ObtenerFidelizadosQuery request, CancellationToken cancellationToken)
        {
            var parameter = new Dictionary<string, object>
            {
                {"Filtro", "'"+request.Filtro+"'" ?? "''" }
            };
            var fidelizados = await _repositorioGenerico.ExecuteStoredProcedure("SPObtenerFidelizados", parameter);
            return _mapper.Map<IEnumerable<FidelizadoDto>>(fidelizados);

        }
    }
}
