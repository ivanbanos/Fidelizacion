namespace Dominio.Entidades
{
    public class Compania
    {
        public Compania()
        {
            CentroVentas = new List<CentroVenta>();
        }
        public int? Id { get; set; }
        public string Nombre { get; set; }
        public int VigenciaPuntos { get; set; }
        public int TipoVencimientoId { get; set; }
        public virtual TipoVencimiento? TipoVencimiento { get; set; }
        public int EstadoId { get; set; }
        public virtual Estado? Estado { get; set; }
        public virtual IEnumerable<CentroVenta>? CentroVentas { get; set; }
    }
}