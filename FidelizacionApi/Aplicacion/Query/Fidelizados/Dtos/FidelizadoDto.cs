namespace Aplicacion.Query.Fidelizados.Dtos
{
    public class FidelizadoDto
    {
        public int Id { get; set; }
        public string Documento { get; set; }
        public int TipoDocumentoId { get; set; }
        public string Nombre { get; set; }
        public float? Puntos { get; set; }
        public float? PuntosReservados { get; set; }
        public float PorcentajePuntos { get; set; }
        public int EstadoId { get; set; }
        public string? Telefono { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public int? Estrato { get; set; }
        public int? NumeroHijos { get; set; }
        public int SexoId { get; set; }
        public int CiudadId { get; set; }
        public string NombreCiudad { get; set; }
        public int? ProfesionId { get; set; }
    }
}
