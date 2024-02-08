using MediatR;

namespace Aplicacion.Command.CentroVentas
{
    public class AgregarCentroVentaCommand : IRequest<bool>
    {
        public string Nit { get; }
        public string Nombre { get; }
        public string Direccion { get; }
        public string Telefono { get; }
        public int ValorPorPunto { get; }
        public int CompaniaId { get; }
        public int CiudadId { get; }

        public AgregarCentroVentaCommand(string nit, 
            string nombre, 
            string direccion, 
            string telefono, 
            int valorPorPunto, 
            int companiaId, 
            int ciudadId)
        {
            Nit = nit;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            ValorPorPunto = valorPorPunto;
            CompaniaId = companiaId;
            CiudadId = ciudadId;
        }
    }
}
