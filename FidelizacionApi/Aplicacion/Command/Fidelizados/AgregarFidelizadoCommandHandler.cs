using Aplicacion.Exepciones;
using Aplicacion.Extension;
using Datos.Common;
using Dominio.Common.Enum;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Aplicacion.Command.Fidelizados
{
    public class AgregarFidelizadoCommandHandler : IRequestHandler<AgregarFidelizadoCommand, bool>
    {
        private readonly ILogger<AgregarFidelizadoCommandHandler> _logger;
        private readonly IRepositorioGenerico<Fidelizado> _repositorioGenerico;
        private readonly IRepositorioGenerico<Usuario> _repositorioGenericoUsuario;

        public AgregarFidelizadoCommandHandler(ILogger<AgregarFidelizadoCommandHandler> logger, IRepositorioGenerico<Fidelizado> repositorioGenerico, IRepositorioGenerico<Usuario> repositorioGenericoUsuario)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
            _repositorioGenericoUsuario = repositorioGenericoUsuario;
        }

        public async Task<bool> Handle(AgregarFidelizadoCommand request, CancellationToken cancellationToken)
        {
            var usuarios = await _repositorioGenericoUsuario.GetAsync(u => u.Guid.Equals(request.Usuario) 
                                                                            && u.CentroVentaId == request.Fidelizado.CentroVentaId);
            var usuario = usuarios.FirstOrDefault();
            if (usuario == null)
            {
                throw new ApiException() { ExceptionMessage = "Usuario no existe", StatusCode = HttpStatusCode.BadRequest };
            }
            var fidelizado = await _repositorioGenerico
                                        .GetAsync(f => f.Documento.Equals(request.Fidelizado.Documento) 
                                                        && f.CentroVentaId == request.Fidelizado.CentroVentaId);
            if(fidelizado.Any())
            {
                throw new ApiException() { ExceptionMessage = "Fidelizado ya existe", StatusCode = HttpStatusCode.BadRequest };
            }
            request.Fidelizado.EstadoId = (int)EstadoEnum.Activo;
            request.Fidelizado.FechaCreacion = DateTime.Now;
            request.Fidelizado.InformacionAdicional.UsuarioId = usuario.Id;
            request.Fidelizado.Contrasena = request.Fidelizado.Documento.Hash();

            await _repositorioGenerico.AddAsync(request.Fidelizado);
            return true;
        }
    }
}
