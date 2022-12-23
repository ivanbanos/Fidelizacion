using Aplicacion.Command.Puntos;
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

        [HttpPost]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> Create(AgregarPuntosCommand agregarPuntos, CancellationToken cancellationToken)
        {
            return await _mediator.Send(agregarPuntos, cancellationToken);
        }
    }
}
