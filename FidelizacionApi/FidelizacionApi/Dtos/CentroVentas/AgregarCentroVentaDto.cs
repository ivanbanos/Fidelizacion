namespace FidelizacionApi.Dtos.CentroVentas
{
    public class AgregarCentroVentaDto
    {
        public string Nit { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int ValorPorPunto { get; set; }
        public int CiudadId { get; set; }
        public int? CompaniaId { get; set; }
    }
}
