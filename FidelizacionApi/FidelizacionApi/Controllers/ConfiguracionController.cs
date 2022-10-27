using Aplicacion.Query.Configuraciones;
using Dominio.Entidades;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FidelizacionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfiguracionController : Controller
    {
        private readonly ILogger<ConfiguracionController> _logger;
        private readonly IMediator _mediator;

        public ConfiguracionController(ILogger<ConfiguracionController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("Ciudades")]
        [ProducesResponseType(typeof(IEnumerable<Ciudad>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<Ciudad>> GetCiudades(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ObtenerCiudadesQuery(), cancellationToken);
        }
    }
}
