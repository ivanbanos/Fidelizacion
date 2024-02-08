using AutoMapper;
using Datos.Common;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Command.CentroVentas
{
    public class AgregarCentroVentaCommandHandler : IRequestHandler<AgregarCentroVentaCommand, bool>
    {
        private readonly ILogger<AgregarCentroVentaCommandHandler> _logger;
        private readonly IRepositorioGenerico<CentroVenta> _repositorioGenerico;
        private readonly IMapper _mapper;

        public AgregarCentroVentaCommandHandler(ILogger<AgregarCentroVentaCommandHandler> logger, 
            IRepositorioGenerico<CentroVenta> repositorioGenerico, 
            IMapper mapper)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
            _mapper = mapper;
        }

        public async Task<bool> Handle(AgregarCentroVentaCommand request, CancellationToken cancellationToken)
        {
            var centroDeVenta = _mapper.Map<CentroVenta>(request);
            await _repositorioGenerico.AddAsync(centroDeVenta);
            return true;
        }
    }
}
