using MediatR;

namespace Aplicacion.Command.CentroVentas
{
    public class ActualizarCentroVentaCommand : IRequest<bool>
    {
        public int Id { get; }
        public string Nit { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int ValorPorPunto { get; set; }

        public ActualizarCentroVentaCommand(int id, 
            string nit, 
            string nombre, 
            string direccion, 
            string telefono, 
            int valorPorPunto)
        {
            Id = id;
            Nit = nit;
            Nombre = nombre;
            Direccion = direccion;
            Telefono = telefono;
            ValorPorPunto = valorPorPunto;
        }
    }
}
