namespace Dominio.Entidades
{
    public class Estado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public IEnumerable<Compania> Companias { get; set; }
        public IEnumerable<CentroVenta> CentroVentas { get; set; }
        public IEnumerable<Fidelizado> Fidelizados { get; set; }
    }
}
