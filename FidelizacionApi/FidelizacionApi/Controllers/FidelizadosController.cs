
using Aplicacion.Command.Fidelizados;
using Aplicacion.Query.Fidelizados;
using Dominio.Entidades;
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
        [ProducesResponseType(typeof(IEnumerable<Fidelizado>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<Fidelizado>> GetCentroVenta(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ObtenerFidelizadosQuery(), cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Fidelizado>> GetCentroVentas(int id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ObtenerFidelizadoQuery(id), cancellationToken);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> Put(int id, Fidelizado fidelizado, CancellationToken cancellationToken)
        {
            if (id != fidelizado.Id)
            {
                return false;
            }

            return await _mediator.Send(new ActualizarFidelizadoCommand(id, fidelizado), cancellationToken);
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> Create(Fidelizado fidelizado, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new AgregarFidelizadoCommand(fidelizado), cancellationToken);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new EliminarFidelizadoCommand(id), cancellationToken);
        }
    }
}
