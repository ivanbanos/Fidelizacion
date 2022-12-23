using Aplicacion.Command.Compania;
using Aplicacion.Query.Compania;
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
        public async Task<IEnumerable<Compania>> GetCompania(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ObtenerCompaniasQuery(), cancellationToken);
        }

        // GET: api/Companias/5
        [HttpGet("{id}")]
        [Authtentication.Authorize]
        public async Task<ActionResult<Compania>> GetCompania(int id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ObtenerCompaniaQuery(id), cancellationToken);
        }

        [HttpPut]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> Put(Compania compania, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ActualizarCompaniaCommand(compania), cancellationToken);
        }

        [HttpPost]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> Create(Compania compania, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new AgregarCompaniaCommand(compania), cancellationToken);
        }

        [HttpDelete("{id}")]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> DeleteCompania(int id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new EliminarCompaniaCommand(id), cancellationToken);
        }
    }
}
