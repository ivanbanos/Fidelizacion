
using Aplicacion.Command.Fidelizados;
using Aplicacion.Exepciones;
using Aplicacion.Query.Fidelizados;
using Aplicacion.Query.Fidelizados.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FidelizacionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FidelizadosController : Controller
    {
        private readonly ILogger<FidelizadosController> _logger;
        private readonly IMediator _mediator;

        public FidelizadosController(ILogger<FidelizadosController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(IEnumerable<FidelizadoDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetFidelizados(string? filtro, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(new ObtenerFidelizadosQuery(filtro), cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras se obtenia fidelizados.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }

        [HttpGet("{id}")]
        [Authtentication.Authorize]
        public async Task<IActionResult> GetFidelizado(int id, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(new ObtenerFidelizadoQuery(id), cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras se obtenia fidelizado con id - {id}.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }

        [HttpGet("CentroVenta/{id}")]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(IEnumerable<FidelizadoDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetFidelizadosPorCentroVenta(int id, string? filtro, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(new ObtenerFidelizadosPorCentroVentaQuery(id, filtro), cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras se obtenia fidelizados del centro de venta con id - {id}.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }


        [HttpGet("CentroVenta/{id}/Fidelizado/{documento}")]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(IEnumerable<FidelizadoDto>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetFidelizadosPorCentroVentaYDocumento(int id, string documento, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(new ObtenerFidelizadosPorCentroVentaYDocumentoQuery(id, documento), cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras se obtenia fidelizado del centro de venta con id - {id} y documento - {documento}.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }

        [HttpPut("{id}")]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(int id, ActualizarFidelizadoCommand fidelizado, CancellationToken cancellationToken)
        {
            try
            {
                if (id != fidelizado.Id)
                {
                    return NotFound("Fidelizado no existe");
                }

                return Ok(await _mediator.Send(fidelizado, cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras su actualizaba fidelizado con id - {fidelizado.Id}.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }

        [HttpPost]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(AgregarFidelizadoCommand fidelizadoDto, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(fidelizadoDto, cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras su agregraba fidelizado con número de cédula - {fidelizadoDto.Documento}.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }

        [HttpDelete("{id}")]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(new EliminarFidelizadoCommand(id), cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras su eliminaba fidelizado con id - {id}.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }
    }
}
