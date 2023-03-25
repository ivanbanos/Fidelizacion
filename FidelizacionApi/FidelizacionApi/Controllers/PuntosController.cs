using Aplicacion.Command.Puntos;
using Aplicacion.Exepciones;
using Aplicacion.Query.Facturas;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FidelizacionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuntosController : Controller
    {
        private readonly ILogger<PuntosController> _logger;
        private readonly IMediator _mediator;

        public PuntosController(ILogger<PuntosController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("ValidacionFactura/{nit}/{factura}")]
        [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IActionResult), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ValidacionFactura(string nit, string factura, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _mediator.Send(new ValidacionFacturaQuery(nit, factura), cancellationToken);
                return result ? BadRequest(new { Existe = result, Message = "Factura ya existe" }) 
                              : Ok(new { Existe = result, Message = "Factura no existe" });
            }
            catch (ApiException ex)
            {
                return BadRequest(new { Existe = true, Message = ex.ExceptionMessage });
            }
        }


        [HttpPost]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> Create(AgregarPuntosCommand agregarPuntos, CancellationToken cancellationToken)
        {
            return await _mediator.Send(agregarPuntos, cancellationToken);
        }
    }
}
