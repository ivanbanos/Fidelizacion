using Aplicacion.Command.Premios.Dtos;
using Aplicacion.Exepciones;
using Datos.Common;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Aplicacion.Command.Premios
{
    public class RedencionPremioCommandHandler : IRequestHandler<RedencionPremioCommand, RespuestaRedencionPremioDTO>
    {
        private readonly ILogger<RedencionPremioCommandHandler> _logger;
        private readonly IRepositorioGenerico<Redencion> _repositorioRedencion;
        private readonly IRepositorioGenerico<CentroVenta> _repositorioCentroVenta;
        private readonly IRepositorioGenerico<Fidelizado> _repositorioFidelizado;
        private readonly IRepositorioGenerico<Premio> _repositorioPremio;

        public RedencionPremioCommandHandler(ILogger<RedencionPremioCommandHandler> logger, 
                                                IRepositorioGenerico<Redencion> repositorioRedencion, 
                                                IRepositorioGenerico<CentroVenta> repositorioCentroVenta, 
                                                IRepositorioGenerico<Fidelizado> repositorioFidelizado,
                                                IRepositorioGenerico<Premio> repositorioPremio)
        {
            _logger = logger;
            _repositorioRedencion = repositorioRedencion;
            _repositorioCentroVenta = repositorioCentroVenta;
            _repositorioFidelizado = repositorioFidelizado;
            _repositorioPremio = repositorioPremio;
        }
        public async Task<RespuestaRedencionPremioDTO> Handle(RedencionPremioCommand request, CancellationToken cancellationToken)
        {
            var centroVentas = await _repositorioCentroVenta.GetAsync(f => f.Id.Equals(request.CentroDeVentaId), includeProperties: "Ciudad");

            if (!centroVentas.Any())
                throw new ApiException() { ExceptionMessage = "Centro de venta no existe", StatusCode = HttpStatusCode.BadRequest };

            var centroVenta = centroVentas.FirstOrDefault();

            var fidelizados = await _repositorioFidelizado
                                       .GetAsync(f => f.Documento.Equals(request.DocumentoFidelizado)
                                                        && f.CentroVentaId == centroVenta.Id);
            if (!fidelizados.Any())
                throw new ApiException() { ExceptionMessage = "Fidelizado no existe", StatusCode = HttpStatusCode.BadRequest };

            var fidelizado = fidelizados.FirstOrDefault(f => f.CentroVentaId == centroVenta.Id);

            var premios = await _repositorioPremio.GetAsync(p => p.Guid == request.PremioId);

            if (!premios.Any())
                throw new ApiException() { ExceptionMessage = "Premio no existe", StatusCode = HttpStatusCode.BadRequest };

            var premio = premios.FirstOrDefault();

            if (fidelizado.Puntos < premio.Puntos * request.Cantidad)
                throw new ApiException() { ExceptionMessage = "No cuenta con la cantidad de puntos necesarios para el reclamo", StatusCode = HttpStatusCode.BadRequest };

            fidelizado.Puntos = fidelizado.Puntos - premio.Puntos * request.Cantidad;
            fidelizado.FechaUltimoReclamo = DateTime.Now;

            var redencion = await _repositorioRedencion.AddAsync(new Redencion(premio.Id, fidelizado.Id, centroVenta.Id));
            await _repositorioFidelizado.UpdateAsync(fidelizado);

            return new RespuestaRedencionPremioDTO(premio.Puntos * request.Cantidad, premio.Nombre, request.Cantidad, 
                                                redencion.FechaRedencion.ToString("dd/MM/yyyy, HH:mm:ss"), centroVenta.Ciudad.Nombre, centroVenta.Nombre, 
                                                fidelizado.Documento, fidelizado.Nombre, fidelizado.Puntos.Value);
        }
    }
}
