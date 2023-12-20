namespace Aplicacion.Query.Premios.Dtos
{
    public class PremioDTO
    {
        public Guid Guid { get; set; }
        public string Nombre { get; set; }
        public int Puntos { get; set; }
        public float Precio { get; set; }
        public string FechaInicio { get; set; }
        public string FechaFin { get; set; }
    }
}
