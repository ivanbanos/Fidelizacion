using Aplicacion.Command.CentroVentas;
using Aplicacion.Exepciones;
using Aplicacion.Query.CentroVentas;
using Dominio.Entidades;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FidelizacionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CentroVentasController : Controller
    {
        private readonly ILogger<CentroVentasController> _logger;
        private readonly IMediator _mediator;

        public CentroVentasController(ILogger<CentroVentasController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(IEnumerable<CentroVenta>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCentroVentas(CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(new ObtenerCentroVentasQuery(), cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras se obtenian los centros de ventas.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }

        [HttpGet("{id}")]
        [Authtentication.Authorize]
        public async Task<IActionResult> GetCentroVenta(int id, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(new ObtenerCentroVentaQuery(id), cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras se obtenia el centro de venta.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }

        [HttpGet("Compania/{id}")]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(IEnumerable<CentroVenta>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCentroVentasPorCompania(int id, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(new ObtenerCentroVentasPorCompaniaQuery(id), cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras se obtenian los centros de ventas.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }

        [HttpPut]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(ActualizarCentroVentaCommand centroVenta, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(centroVenta, cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras se actualizaba el centro de venta.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }

        [HttpPost]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(AgregarCentroVentaCommand centroVenta, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(centroVenta, cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras se creaba el centro de venta.", ex);
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
                return Ok(await _mediator.Send(new EliminarCentroVentaCommand(id), cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras se eliminaba el centro venta.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }
    }
}
