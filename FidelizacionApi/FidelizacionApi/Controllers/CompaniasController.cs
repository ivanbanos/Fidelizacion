using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Datos;
using Dominio.Entidades;
using System.Net;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using Aplicacion.Command.Compania;
using Aplicacion.Query.Compania;

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
        [ProducesResponseType(typeof(IEnumerable<Compania>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<Compania>> GetCompania(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ObtenerCompaniasQuery(), cancellationToken);
        }

        // GET: api/Companias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Compania>> GetCompania(int id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ObtenerCompaniaQuery(id), cancellationToken);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> Put(int id, Compania compania, CancellationToken cancellationToken)
        {
            if (id != compania.Id)
            {
                return false;
            }

            return await _mediator.Send(new ActualizarCompaniaCommand(id, compania), cancellationToken);
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> Create(Compania compania, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new AgregarCompaniaCommand(compania), cancellationToken);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> DeleteCompania(int id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new EliminarCompaniaCommand(id), cancellationToken);
        }
    }
}
