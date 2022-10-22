namespace Dominio.Entidades
{
    public class Compania
    {
        public int? Id { get; set; }
        public string Nombre { get; set; }
        public int VigenciaPuntos { get; set; }
        public int TipoVencimientoId { get; set; }
        public TipoVencimiento? TipoVencimiento { get; set; }
    }
}