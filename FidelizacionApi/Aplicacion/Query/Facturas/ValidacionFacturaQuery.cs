using MediatR;

namespace Aplicacion.Query.Facturas
{
    public  class ValidacionFacturaQuery : IRequest<bool>
    {
        public ValidacionFacturaQuery(string nit, string factura)
        {
            Nit = nit;
            Factura = factura;
        }

        public string Nit { get; set; }
        public string Factura { get; set; }
    }
}
