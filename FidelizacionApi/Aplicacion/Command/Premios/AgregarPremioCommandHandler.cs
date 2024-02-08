using Aplicacion.Exepciones;
using AutoMapper;
using Datos.Common;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Aplicacion.Command.Premios
{
    public class AgregarPremioCommandHandler : IRequestHandler<AgregarPremioCommand, bool>
    {
        private readonly ILogger<AgregarPremioCommandHandler> _logger;
        private readonly IRepositorioGenerico<Premio> _repositorioPremio;
        private readonly IRepositorioGenerico<CentroVenta> _repositorioCentroDeVenta;
        private readonly IMapper _mapper;

        public AgregarPremioCommandHandler(ILogger<AgregarPremioCommandHandler> logger, IRepositorioGenerico<Premio> repositorioPremio, IRepositorioGenerico<CentroVenta> repositorioCentroDeVenta, IMapper mapper)
        {
            _logger = logger;
            _repositorioPremio = repositorioPremio;
            _repositorioCentroDeVenta = repositorioCentroDeVenta;
            _mapper = mapper;
        }

        public async Task<bool> Handle(AgregarPremioCommand request, CancellationToken cancellationToken)
        {
            var centroDeVentas = await _repositorioCentroDeVenta.GetAsync(cv => cv.Id == request.CentroDeVentaId);
            if (!centroDeVentas.Any())
                throw new ApiException() { ExceptionMessage = "Centro de venta no existe", StatusCode = HttpStatusCode.BadRequest };

            var centroDeVenta = centroDeVentas.FirstOrDefault();

            var premio = _mapper.Map<Premio>(request);
            premio.CompaniaId = centroDeVenta.CompaniaId;
            var premioCreado = await _repositorioPremio.AddAsync(premio);
            return premioCreado != null;
        }
    }
}
