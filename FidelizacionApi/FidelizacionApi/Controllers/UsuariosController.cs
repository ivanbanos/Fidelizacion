using Aplicacion.Command.Usuarios;
using Aplicacion.Exepciones;
using Aplicacion.Query.Usuarios;
using Aplicacion.Query.ValidacionUsuario;
using Dominio.Autenticacion;
using Dominio.Entidades;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FidelizacionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : Controller
    {
        private readonly ILogger<UsuariosController> _logger;
        private readonly IMediator _mediator;

        public UsuariosController(ILogger<UsuariosController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(CrearUsuarioCommand usuario, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(usuario, cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras se creaba el usuario.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }

        [HttpGet]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(IEnumerable<Usuario>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUsuario(CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(new ObtenerUsuariosQuery(), cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras se obtenian los usuarios.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }

        [HttpGet("CentroVenta/{id}")]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(IEnumerable<Usuario>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUsuariosPorCentroVenta(int id, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(new ObtenerUsuariosPorCentroVentaQuery(id), cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras se obtenian los usuarios por centro de venta.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }

        [HttpGet("Compania/{id}")]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(IEnumerable<Usuario>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUsuariosPorCompania(int id, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(new ObtenerUsuariosPorCompaniaQuery(id), cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras se obtenian los usuarios por compañia.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }

        [HttpGet("{nombreUsuario}/{contrasena}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(AuthenticationInfo), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> Authenticate(string nombreUsuario, string contrasena, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(new ValidacionUsuarioContrasenaQuery(nombreUsuario, contrasena), cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras se autenticaba el usuario.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }

        [HttpPut]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(ActualizarUsuarioCommand usuario, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(usuario, cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras se actualizaba el usuario.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }

        [HttpDelete("{usuario}")]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(Guid usuario, CancellationToken cancellationToken)
        {
            try
            {
                return Ok(await _mediator.Send(new EliminarUsuarioCommand(usuario), cancellationToken));
            }
            catch (Exception ex) when (ex is not ApiException)
            {
                _logger.LogError($"Error mientras se eliminaba el usuario.", ex);
                return StatusCode(500, "Ocurrió un error mientras se procesaba su petición.");
            }
        }
    }
}
