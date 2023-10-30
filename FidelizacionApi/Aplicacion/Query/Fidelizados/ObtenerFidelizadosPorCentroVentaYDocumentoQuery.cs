using Dominio.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Query.Fidelizados
{
    public class ObtenerFidelizadosPorCentroVentaYDocumentoQuery : IRequest<IEnumerable<Fidelizado>>
    {
        public ObtenerFidelizadosPorCentroVentaYDocumentoQuery(int id, string documento)
        {
            Id = id;
            Documento = documento;
        }

        public int Id { get; }
        public string Documento { get; }
    }
}
