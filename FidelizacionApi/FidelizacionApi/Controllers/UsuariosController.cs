using Aplicacion.Command.Usuarios;
using Aplicacion.Query.Usuarios;
using Aplicacion.Query.ValidacionUsuario;
using Dominio.Autenticacion;
using Dominio.Entidades;
using FidelizacionApi.Dtos.Usuarios;
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
        public async Task<bool> Create(AgregarUsuarioDto usuario, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new CrearUsuarioCommand(new Usuario { NombreUsuario = usuario.NombreUsuario, CentroVentaId = usuario.CentroVentaId, PerfilId = usuario.Perfil, Guid = Guid.NewGuid() }), cancellationToken);
        }

        [HttpGet]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(IEnumerable<Usuario>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<Usuario>> GetUsuario(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ObtenerUsuariosQuery(), cancellationToken);
        }

        [HttpGet("CentroVenta/{id}")]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(IEnumerable<Usuario>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<Usuario>> GetUsuariosPorCentroVenta(int id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ObtenerUsuariosPorCentroVentaQuery(id), cancellationToken);
        }

        [HttpGet("Compania/{id}")]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(IEnumerable<Usuario>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<Usuario>> GetUsuariosPorCompania(int id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ObtenerUsuariosPorCompaniaQuery(id), cancellationToken);
        }

        [HttpGet("{nombreUsuario}/{contrasena}")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(AuthenticationInfo), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        public async Task<AuthenticationInfo> Authenticate(string nombreUsuario, string contrasena, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ValidacionUsuarioContrasenaQuery(nombreUsuario, contrasena), cancellationToken);
        }

        [HttpPut]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> Update(Usuario usuario, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ActualizarUsuarioCommand(usuario), cancellationToken);
        }

        [HttpDelete("{usuario}")]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> Delete(Guid usuario, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new EliminarUsuarioCommand(usuario), cancellationToken);
        }
    }
}
