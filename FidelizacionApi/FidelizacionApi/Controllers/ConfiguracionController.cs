using Aplicacion.Command.Contrasena;
using Aplicacion.Query.Configuraciones;
using Dominio.Entidades;
using FidelizacionApi.Dtos.Contrasena;
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

        [HttpPut("Contrasena")]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> Update(ActualizarContrasenaDto contrasenaDto, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ActualizarContrasenaCommand(contrasenaDto.Usuario, contrasenaDto.Contrasena), cancellationToken);
        }

        [HttpGet]
        [Route("Ciudades")]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(IEnumerable<Ciudad>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<Ciudad>> GetCiudades(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ObtenerCiudadesQuery(), cancellationToken);
        }

        [HttpGet]
        [Route("Perfiles")]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(IEnumerable<Perfil>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<Perfil>> GetPerfiles(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ObtenerPerfilesQuery(), cancellationToken);
        }
    }
}
