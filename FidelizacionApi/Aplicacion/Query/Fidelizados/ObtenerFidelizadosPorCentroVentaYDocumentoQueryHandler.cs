﻿using Aplicacion.Query.Fidelizados.Dtos;
using AutoMapper;
using Datos.Common;
using Dominio.Common.Enum;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Query.Fidelizados
{
    internal class ObtenerFidelizadosPorCentroVentaYDocumentoQueryHandler : IRequestHandler<ObtenerFidelizadosPorCentroVentaYDocumentoQuery, IEnumerable<FidelizadoDto>>
    {
        private readonly ILogger<ObtenerFidelizadosPorCentroVentaQueryHandler> _logger;
        private readonly IRepositorioGenerico<Fidelizado> _repositorioGenerico;
        private readonly IMapper _mapper;

        public ObtenerFidelizadosPorCentroVentaYDocumentoQueryHandler(ILogger<ObtenerFidelizadosPorCentroVentaQueryHandler> logger, IRepositorioGenerico<Fidelizado> repositorioGenerico, IMapper mapper)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FidelizadoDto>> Handle(ObtenerFidelizadosPorCentroVentaYDocumentoQuery request, CancellationToken cancellationToken)
        {
            var fidelizados = await _repositorioGenerico.GetAsync(f => f.EstadoId == (int)EstadoEnum.Activo && f.CentroVentaId == request.Id && f.Documento == request.Documento, includeProperties: "InformacionAdicional,InformacionAdicional.Ciudad");
            return _mapper.Map<IEnumerable<FidelizadoDto>>(fidelizados);

        }
    }
}
