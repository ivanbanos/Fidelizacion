namespace Dominio.Entidades
{
    public class TipoVencimiento
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public IEnumerable<Compania> Companias { get; set; }
    }
}
