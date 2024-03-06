using Aplicacion.Query.Fidelizados.Dtos;
using AutoMapper;
using Datos.Common;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Query.Fidelizados
{
    public class ObtenerFidelizadoHandler : IRequestHandler<ObtenerFidelizadoQuery, FidelizadoDto>
    {
        private readonly ILogger<ObtenerFidelizadoHandler> _logger;
        private readonly IRepositorioGenerico<Fidelizado> _repositorioGenerico;
        private readonly IMapper _mapper;

        public ObtenerFidelizadoHandler(ILogger<ObtenerFidelizadoHandler> logger, 
                                        IRepositorioGenerico<Fidelizado> repositorioGenerico, 
                                        IMapper mapper)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
            _mapper = mapper;
        }

        public async Task<FidelizadoDto> Handle(ObtenerFidelizadoQuery request, CancellationToken cancellationToken)
        {
            var fidelizado = await _repositorioGenerico.GetByIdAsync(request.Id);
            return _mapper.Map<FidelizadoDto>(fidelizado);

        }
    }
}
