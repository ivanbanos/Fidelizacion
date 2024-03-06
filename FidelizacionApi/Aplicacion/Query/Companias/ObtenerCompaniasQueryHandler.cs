using Aplicacion.Query.Companias.Dtos;
using AutoMapper;
using Datos.Common;
using Dominio.Common.Enum;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Query.Companias
{
    public class ObtenerCompaniasQueryHandler : IRequestHandler<ObtenerCompaniasQuery, IEnumerable<CompaniaDto>>
    {
        private readonly ILogger<ObtenerCompaniasQueryHandler> _logger;
        private readonly IRepositorioGenerico<Compania> _repositorioGenerico;
        private readonly IMapper _mapper;


        public ObtenerCompaniasQueryHandler(ILogger<ObtenerCompaniasQueryHandler> logger, 
                                            IRepositorioGenerico<Compania> repositorioGenerico,
                                            IMapper mapper)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompaniaDto>> Handle(ObtenerCompaniasQuery request, CancellationToken cancellationToken)
        {
            var compania = await _repositorioGenerico.GetAsync(c => c.EstadoId == (int)EstadoEnum.Activo);
            return _mapper.Map<IEnumerable<CompaniaDto>>(compania);

        }
    }
}
