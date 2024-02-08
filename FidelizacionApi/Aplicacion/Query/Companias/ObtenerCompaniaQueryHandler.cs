using Aplicacion.Query.Companias.Dtos;
using AutoMapper;
using Datos.Common;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Query.Companias
{
    public class ObtenerCompaniaQueryHandler : IRequestHandler<ObtenerCompaniaQuery, CompaniaDto>
    {
        private readonly ILogger<ObtenerCompaniaQueryHandler> _logger;
        private readonly IRepositorioGenerico<Compania> _repositorioGenerico;
        private readonly IMapper _mapper;

        public ObtenerCompaniaQueryHandler(ILogger<ObtenerCompaniaQueryHandler> logger, 
                                            IRepositorioGenerico<Compania> repositorioGenerico,
                                            IMapper mapper)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
            _mapper = mapper;
        }

        public async Task<CompaniaDto> Handle(ObtenerCompaniaQuery request, CancellationToken cancellationToken)
        {
            var compania = await _repositorioGenerico.GetByIdAsync(request.Id);
            return _mapper.Map<CompaniaDto>(compania);

        }
    }
}
