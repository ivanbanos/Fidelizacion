namespace Dominio.Entidades
{
    public class Ciudad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
        public IEnumerable<CentroVenta> CentroVentas { get; set; }
    }
}
