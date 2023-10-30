using Datos.Common;
using Dominio.Common.Enum;
using Dominio.Entidades;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Query.Fidelizados
{
    internal class ObtenerFidelizadosPorCentroVentaYDocumentoQueryHandler : IRequestHandler<ObtenerFidelizadosPorCentroVentaYDocumentoQuery, IEnumerable<Fidelizado>>
    {
        private readonly ILogger<ObtenerFidelizadosPorCentroVentaQueryHandler> _logger;
        private readonly IRepositorioGenerico<Fidelizado> _repositorioGenerico;

        public ObtenerFidelizadosPorCentroVentaYDocumentoQueryHandler(ILogger<ObtenerFidelizadosPorCentroVentaQueryHandler> logger, IRepositorioGenerico<Fidelizado> repositorioGenerico)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
        }

        public Task<IEnumerable<Fidelizado>> Handle(ObtenerFidelizadosPorCentroVentaYDocumentoQuery request, CancellationToken cancellationToken)
        {
            return _repositorioGenerico.GetAsync(f => f.EstadoId == (int)EstadoEnum.Activo && f.CentroVentaId == request.Id && f.Documento == request.Documento, includeProperties: "InformacionAdicional,InformacionAdicional.Ciudad");

        }
    }
}
