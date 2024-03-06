using MediatR;

namespace Aplicacion.Command.Premios
{
    public class ActualizarPremioCommand : IRequest<bool>
    {
        public Guid Guid { get; set; }
        public string Nombre { get; set; }
        public int Puntos { get; set; }
        public float Precio { get; set; }
        public DateTime FechaFin { get; set; }
        public int CentroVentaId { get; set; }

        public ActualizarPremioCommand(Guid guid, string nombre, int puntos, float precio, DateTime fechaFin, int centroVentaId)
        {
            Guid = guid;
            Nombre = nombre;
            Puntos = puntos;
            Precio = precio;
            FechaFin = fechaFin;
            CentroVentaId = centroVentaId;
        }
    }
}
