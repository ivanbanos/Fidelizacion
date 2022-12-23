
using Aplicacion.Command.Fidelizados;
using Aplicacion.Query.Fidelizados;
using Dominio.Entidades;
using FidelizacionApi.Dtos;
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
        [ProducesResponseType(typeof(IEnumerable<Fidelizado>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<Fidelizado>> GetFidelizados(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ObtenerFidelizadosQuery(), cancellationToken);
        }

        [HttpGet("{id}")]
        [Authtentication.Authorize]
        public async Task<ActionResult<Fidelizado>> GetFidelizado(int id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ObtenerFidelizadoQuery(id), cancellationToken);
        }

        [HttpGet("CentroVenta/{id}")]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(IEnumerable<Fidelizado>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<Fidelizado>> GetFidelizadosPorCentroVenta(int id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ObtenerFidelizadosPorCentroVentaQuery(id), cancellationToken);
        }

        [HttpPut("{id}")]
        [Authtentication.Authorize]
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
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> Create(AgregarFidelizadoDto fidelizadoDto, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new AgregarFidelizadoCommand(fidelizadoDto.Fidelizado, fidelizadoDto.Usuario), cancellationToken);
        }

        [HttpDelete("{id}")]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new EliminarFidelizadoCommand(id), cancellationToken);
        }
    }
}
