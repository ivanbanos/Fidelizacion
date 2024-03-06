using Aplicacion.Command.Contrasena;
using Aplicacion.Exepciones;
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
        public async Task<IActionResult> GetCiudades(CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(new ObtenerCiudadesQuery(), cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras se obtenian los usuarios.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }

        [HttpGet]
        [Route("Perfiles")]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(IEnumerable<Perfil>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetPerfiles(CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(new ObtenerPerfilesQuery(), cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras se obtenian los usuarios.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }
    }
}
