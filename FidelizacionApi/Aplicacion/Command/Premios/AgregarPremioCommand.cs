using MediatR;

namespace Aplicacion.Command.Premios
{
    public class AgregarPremioCommand : IRequest<bool>
    {
        public string Nombre { get;}
        public int Puntos { get;}
        public float Precio { get; }
        public DateTime FechaFin { get; }
        public int CentroDeVentaId { get; }

        public AgregarPremioCommand(string nombre, int puntos, float precio, DateTime fechaFin, int centroDeVentaId)
        {
            Nombre = nombre;
            Puntos = puntos;
            Precio = precio;
            FechaFin = fechaFin;
            CentroDeVentaId = centroDeVentaId;
        }
    }
}
