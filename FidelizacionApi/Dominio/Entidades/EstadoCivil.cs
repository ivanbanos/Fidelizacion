namespace Dominio.Entidades
{
    public class EstadoCivil
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual IEnumerable<InformacionAdicional> InformacionesAdicionales { get; set; }
    }
}
