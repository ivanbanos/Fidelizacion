using Datos.Common;
using Dominio.Common.Enum;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aplicacion.Query.Usuarios
{
    public class ObtenerUsuariosPorCompaniaQueryHandler : IRequestHandler<ObtenerUsuariosPorCompaniaQuery, IEnumerable<Dominio.Entidades.Usuario>>
    {
        private readonly ILogger<ObtenerUsuariosPorCompaniaQueryHandler> _logger;
        private readonly IRepositorioGenerico<Dominio.Entidades.Usuario> _repositorioGenerico;

        public ObtenerUsuariosPorCompaniaQueryHandler(ILogger<ObtenerUsuariosPorCompaniaQueryHandler> logger, IRepositorioGenerico<Dominio.Entidades.Usuario> repositorioGenerico)
        {
            _logger = logger;
            _repositorioGenerico = repositorioGenerico;
        }

        public Task<IEnumerable<Dominio.Entidades.Usuario>> Handle(ObtenerUsuariosPorCompaniaQuery request, CancellationToken cancellationToken)
        {
            return _repositorioGenerico.GetAsync(u => u.EstadoId == (int)EstadoEnum.Activo && u.CentroVenta.CompaniaId == request.Id, includeProperties: "CentroVenta");
        }
    }
}
