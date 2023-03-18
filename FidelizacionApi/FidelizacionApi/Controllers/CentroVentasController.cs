using Aplicacion.Command.CentroVentas;
using Aplicacion.Query.CentroVentas;
using Dominio.Entidades;
using FidelizacionApi.Dtos.CentroVentas;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FidelizacionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CentroVentasController : Controller
    {
        private readonly ILogger<CentroVentasController> _logger;
        private readonly IMediator _mediator;

        public CentroVentasController(ILogger<CentroVentasController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(IEnumerable<CentroVenta>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<CentroVenta>> GetCentroVenta(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ObtenerCentroVentasQuery(), cancellationToken);
        }

        [HttpGet("{id}")]
        [Authtentication.Authorize]
        public async Task<ActionResult<CentroVenta>> GetCentroVentas(int id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ObtenerCentroVentaQuery(id), cancellationToken);
        }

        [HttpGet("Compania/{id}")]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(IEnumerable<CentroVenta>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<CentroVenta>> GetCentroVentasPorCpmpania(int id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ObtenerCentroVentasPorCompaniaQuery(id), cancellationToken);
        }

        [HttpPut]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> Put(CentroVenta centroVenta, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new ActualizarCentroVentaCommand(centroVenta), cancellationToken);
        }

        [HttpPost]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> Create(AgregarCentroVentaDto centroVenta, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new AgregarCentroVentaCommand(new CentroVenta { Nit = centroVenta.Nit, Nombre = centroVenta.Nombre, Direccion = centroVenta.Direccion, Telefono = centroVenta.Telefono, ValorPorPunto = centroVenta.ValorPorPunto, CiudadId = centroVenta.CiudadId, CompaniaId = centroVenta.CompaniaId.Value }), cancellationToken);
        }

        [HttpDelete("{id}")]
        [Authtentication.Authorize]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new EliminarCentroVentaCommand(id), cancellationToken);
        }
    }
}
