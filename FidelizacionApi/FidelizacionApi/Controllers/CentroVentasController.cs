using Aplicacion.Command.CentroVentas;
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
        [ProducesResponseType(typeof(IEnumerable<CentroVenta>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<CentroVenta>> GetCentroVenta(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ObtenerCentroVentasQuery(), cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CentroVenta>> GetCentroVentas(int id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ObtenerCentroVentaQuery(id), cancellationToken);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> Put(int id, CentroVenta centroVenta, CancellationToken cancellationToken)
        {
            if (id != centroVenta.Id)
            {
                return false;
            }

            return await _mediator.Send(new ActualizarCentroVentaCommand(id, centroVenta), cancellationToken);
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> Create(CentroVenta centroVenta, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new AgregarCentroVentaCommand(centroVenta), cancellationToken);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new EliminarCentroVentaCommand(id), cancellationToken);
        }
    }
}
