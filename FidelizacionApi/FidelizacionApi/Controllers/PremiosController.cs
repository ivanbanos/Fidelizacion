using Aplicacion.Command.Premios;
using Aplicacion.Command.Premios.Dtos;
using Aplicacion.Query.Premios;
using Aplicacion.Query.Premios.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FidelizacionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authtentication.Authorize]
    public class PremiosController : ControllerBase
    {
        private readonly ILogger<PremiosController> _logger;
        private readonly IMediator _mediator;
        public PremiosController(ILogger<PremiosController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("{centroVentaId}")]
        [ProducesResponseType(typeof(IEnumerable<PremioDTO>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<PremioDTO>> GetPremios(int centroVentaId, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ObtenerPremiosQuery(centroVentaId), cancellationToken);
        }


        [HttpGet("{centroVentaId}/Vigentes")]
        [ProducesResponseType(typeof(IEnumerable<PremioDTO>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<PremioDTO>> GetPremiosVigentes(int centroVentaId, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ObtenerPremiosVigentesQuery(centroVentaId), cancellationToken);
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> Create(AgregarPremioCommand agregarPremio, CancellationToken cancellationToken)
        {
            return await _mediator.Send(agregarPremio, cancellationToken);
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> Update(ActualizarPremioCommand actualizarPremio, CancellationToken cancellationToken)
        {
            return await _mediator.Send(actualizarPremio, cancellationToken);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> Delete(EliminarPremioCommand eliminarPremio, CancellationToken cancellationToken)
        {
            return await _mediator.Send(eliminarPremio, cancellationToken);
        }

        [HttpPost("Redimir")]
        [ProducesResponseType(typeof(RespuestaRedencionPremioDTO), (int)HttpStatusCode.OK)]
        public async Task<RespuestaRedencionPremioDTO> Redimir(RedencionPremioCommand redimirPremio, CancellationToken cancellationToken)
        {
            return await _mediator.Send(redimirPremio, cancellationToken);
        }
    }
}
