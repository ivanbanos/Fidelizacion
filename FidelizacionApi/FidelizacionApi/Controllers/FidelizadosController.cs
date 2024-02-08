
using Aplicacion.Command.Fidelizados;
using Aplicacion.Query.Fidelizados;
using Aplicacion.Query.Fidelizados.Dtos;
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
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(IEnumerable<FidelizadoDto>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<FidelizadoDto>> GetFidelizados(string? filtro, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ObtenerFidelizadosQuery(filtro), cancellationToken);
        }

        [HttpGet("{id}")]
        [Authtentication.Authorize]
        public async Task<ActionResult<FidelizadoDto>> GetFidelizado(int id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ObtenerFidelizadoQuery(id), cancellationToken);
        }

        [HttpGet("CentroVenta/{id}")]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(IEnumerable<FidelizadoDto>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<FidelizadoDto>> GetFidelizadosPorCentroVenta(int id, string? filtro, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ObtenerFidelizadosPorCentroVentaQuery(id, filtro), cancellationToken);
        }


        [HttpGet("CentroVenta/{id}/Fidelizado/{documento}")]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(IEnumerable<FidelizadoDto>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<FidelizadoDto>> GetFidelizadosPorCentroVentaYDocumento(int id, string documento, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ObtenerFidelizadosPorCentroVentaYDocumentoQuery(id, documento), cancellationToken);
        }

        [HttpPut("{id}")]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> Put(int id, ActualizarFidelizadoCommand fidelizado, CancellationToken cancellationToken)
        {
            if (id != fidelizado.Id)
            {
                return false;
            }

            return await _mediator.Send(fidelizado, cancellationToken);
        }

        [HttpPost]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> Create(AgregarFidelizadoCommand fidelizadoDto, CancellationToken cancellationToken)
        {
            return await _mediator.Send(fidelizadoDto, cancellationToken);
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
