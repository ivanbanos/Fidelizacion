using Aplicacion.Command.Premios;
using Aplicacion.Command.Premios.Dtos;
using Aplicacion.Exepciones;
using Aplicacion.Query.Premios;
using Aplicacion.Query.Premios.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FidelizacionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authtentication.Authorize]
    public class PremiosController : ControllerBase
    {
        private readonly ILogger<PremiosController> _logger;
        private readonly IMediator _mediator;
        public PremiosController(ILogger<PremiosController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("{centroVentaId}")]
        [ProducesResponseType(typeof(IEnumerable<PremioDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetPremios(int centroVentaId, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(new ObtenerPremiosQuery(centroVentaId), cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras se obtenian los premios.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }


        [HttpGet("{centroVentaId}/Vigentes")]
        [ProducesResponseType(typeof(IEnumerable<PremioDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetPremiosVigentes(int centroVentaId, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(new ObtenerPremiosVigentesQuery(centroVentaId), cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras se obtenian los premios.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(AgregarPremioCommand agregarPremio, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(agregarPremio, cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras se agregaba un premio.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(ActualizarPremioCommand actualizarPremio, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(actualizarPremio, cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras se actualizaba un premio.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }

        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(EliminarPremioCommand eliminarPremio, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(eliminarPremio, cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras se eliminaba un premio.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }

        [HttpPost("Redimir")]
        [ProducesResponseType(typeof(RespuestaRedencionPremioDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Redimir(RedencionPremioCommand redimirPremio, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(redimirPremio, cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras se redimía un premio.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }
    }
}
