using AutoMapper;
using Datos.Common;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Command.Companias
{
    public class AgregarCompaniaCommandHandler : IRequestHandler<AgregarCompaniaCommand, bool>
    {
        private readonly ILogger<AgregarCompaniaCommandHandler> _logger;
        private readonly IRepositorioGenerico<Compania> _repositorioGenerico;
        private readonly IMapper _mapper;

        public AgregarCompaniaCommandHandler(ILogger<AgregarCompaniaCommandHandler> logger, 
            IRepositorioGenerico<Compania> repositorioGenerico,
            IMapper mapper)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
            _mapper = mapper;
        }

        public async Task<bool> Handle(AgregarCompaniaCommand request, CancellationToken cancellationToken)
        {
            var compania = _mapper.Map<Compania>(request);
            await _repositorioGenerico.AddAsync(compania);
            return true;
        }
    }
}
