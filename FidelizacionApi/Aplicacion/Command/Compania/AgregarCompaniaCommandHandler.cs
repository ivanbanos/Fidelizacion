﻿using Datos.Common;
using Dominio.Common.Enum;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Command.Compania
{
    public class AgregarCompaniaCommandHandler : IRequestHandler<AgregarCompaniaCommand, bool>
    {
        private readonly ILogger<AgregarCompaniaCommandHandler> _logger;
        private readonly IRepositorioGenerico<Dominio.Entidades.Compania> _repositorioGenerico;

        public AgregarCompaniaCommandHandler(ILogger<AgregarCompaniaCommandHandler> logger, IRepositorioGenerico<Dominio.Entidades.Compania> repositorioGenerico)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
        }

        public async Task<bool> Handle(AgregarCompaniaCommand request, CancellationToken cancellationToken)
        {
            request.Compania.EstadoId = (int)EstadoEnum.Activo;
            await _repositorioGenerico.AddAsync(request.Compania);
            return true;
        }
    }
}
