using Aplicacion.Command.Companias;
using Aplicacion.Exepciones;
using Aplicacion.Query.Companias;
using Dominio.Entidades;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FidelizacionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniasController : ControllerBase
    {
        private readonly ILogger<CompaniasController> _logger;
        private readonly IMediator _mediator;

        public CompaniasController(ILogger<CompaniasController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        // GET: api/Companias
        [HttpGet]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(IEnumerable<Compania>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCompania(CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(new ObtenerCompaniasQuery(), cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras se obtenian las compañias.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }

        // GET: api/Companias/5
        [HttpGet("{id}")]
        [Authtentication.Authorize]
        public async Task<IActionResult> GetCompania(int id, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(new ObtenerCompaniaQuery(id), cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras se obtenian las compañias.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }

        [HttpPut]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(ActualizarCompaniaCommand compania, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(compania, cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras se obtenian las compañias.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }

        [HttpPost]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(AgregarCompaniaCommand compania, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(compania, cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras se obtenian las compañias.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }

        [HttpDelete("{id}")]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteCompania(int id, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(new EliminarCompaniaCommand(id), cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras se obtenian las compañias.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }
    }
}
