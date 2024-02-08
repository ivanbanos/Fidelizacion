using Aplicacion.Exepciones;
using Aplicacion.Extension;
using AutoMapper;
using Datos.Common;
using Dominio.Common.Enum;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Aplicacion.Command.Usuarios
{
    public class CrearUsuarioCommandHandler : IRequestHandler<CrearUsuarioCommand, bool>
    {
        private readonly ILogger<CrearUsuarioCommandHandler> _logger;
        private readonly IRepositorioGenerico<Usuario> _repositorioGenerico;
        private readonly IMapper _mapper;

        public CrearUsuarioCommandHandler(ILogger<CrearUsuarioCommandHandler> logger, 
                                    IRepositorioGenerico<Usuario> repositorioGenerico,
                                    IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repositorioGenerico = repositorioGenerico ?? throw new ArgumentNullException(nameof(repositorioGenerico));
            _mapper = mapper;
        }

        public async Task<bool> Handle(CrearUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuarios = await _repositorioGenerico.GetAsync(u => u.NombreUsuario.Equals(request.NombreUsuario) 
                                                                    && u.CentroVentaId == request.CentroVentaId);
            if(usuarios.Any())
                throw new ApiException() { ExceptionMessage = "Nombre de usuario ya existe", StatusCode = HttpStatusCode.BadRequest };

            var usuario = new Usuario(request.NombreUsuario, request.Perfil, request.CentroVentaId)
            {
                EstadoId = (int)EstadoEnum.Activo,
                Contrasena = request.NombreUsuario.Hash()
            };

            await _repositorioGenerico.AddAsync(usuario);
            return true;
        }
    }
}
