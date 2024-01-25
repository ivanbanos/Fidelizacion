using Aplicacion.Exepciones;
using Aplicacion.Extension;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public AgregarFidelizadoCommandHandler(ILogger<AgregarFidelizadoCommandHandler> logger, IRepositorioGenerico<Fidelizado> repositorioGenerico, IRepositorioGenerico<Usuario> repositorioGenericoUsuario, IMapper mapper)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
            _repositorioGenericoUsuario = repositorioGenericoUsuario;
            _mapper = mapper;
        }

        public async Task<bool> Handle(AgregarFidelizadoCommand request, CancellationToken cancellationToken)
        {
            var usuarios = await _repositorioGenericoUsuario.GetAsync(u => u.Guid.Equals(request.Usuario) 
                                                                            && u.CentroVentaId == request.CentroVentaId);
            var usuario = usuarios.FirstOrDefault();
            if (usuario == null)
            {
                throw new ApiException() { ExceptionMessage = "Usuario no existe", StatusCode = HttpStatusCode.BadRequest };
            }
            var fidelizados = await _repositorioGenerico
                                        .GetAsync(f => f.Documento.Equals(request.Documento) 
                                                        && f.CentroVentaId == request.CentroVentaId);
            if(fidelizados.Any())
            {
                throw new ApiException() { ExceptionMessage = "Fidelizado ya existe", StatusCode = HttpStatusCode.BadRequest };
            }

            var fidelizado =_mapper.Map<Fidelizado>(request);

            fidelizado.Guid = Guid.NewGuid();
            fidelizado.EstadoId = (int)EstadoEnum.Activo;
            fidelizado.FechaCreacion = DateTime.Now;
            fidelizado.InformacionAdicional.UsuarioId = usuario.Id;
            fidelizado.Contrasena = request.Documento.Hash();

            await _repositorioGenerico.AddAsync(fidelizado);
            return true;
        }
    }
}
