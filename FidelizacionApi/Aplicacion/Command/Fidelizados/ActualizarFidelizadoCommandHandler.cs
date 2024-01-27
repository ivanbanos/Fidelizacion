using AutoMapper;
using Datos.Common;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Command.Fidelizados
{
    public class ActualizarFidelizadoCommandHandler : IRequestHandler<ActualizarFidelizadoCommand, bool>
    {
        private readonly ILogger<ActualizarFidelizadoCommandHandler> _logger;
        private readonly IRepositorioGenerico<Fidelizado> _repositorioGenerico;

        public ActualizarFidelizadoCommandHandler(ILogger<ActualizarFidelizadoCommandHandler> logger, IRepositorioGenerico<Fidelizado> repositorioGenerico)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
        }

        public async Task<bool> Handle(ActualizarFidelizadoCommand request, CancellationToken cancellationToken)
        {
            var fidelizados = await _repositorioGenerico.GetAsync(x => x.Id == request.Id, includeProperties: "InformacionAdicional");

            if (!fidelizados.Any())
                return false;

            var fidelizado = fidelizados.FirstOrDefault();

            fidelizado.Id = request.Id;
            fidelizado.Nombre = request.Nombre;
            fidelizado.PorcentajePuntos = request.PorcentajePuntos;
            fidelizado.InformacionAdicional.Telefono = request.Telefono;
            fidelizado.InformacionAdicional.Celular = request.Celular;
            fidelizado.InformacionAdicional.Direccion = request.Direccion;
            fidelizado.InformacionAdicional.Estrato = request.Estrato;
            fidelizado.InformacionAdicional.NumeroHijos = request.NumeroHijos;
            fidelizado.InformacionAdicional.SexoId = request.SexoId;
            fidelizado.InformacionAdicional.CiudadId = request.CiudadId;
            fidelizado.InformacionAdicional.ProfesionId = request.ProfesionId;

            await _repositorioGenerico.UpdateAsync(fidelizado);
            return true;
        }
    }
}
