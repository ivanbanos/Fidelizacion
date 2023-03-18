namespace Dominio.Entidades
{
    public class Pais
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public virtual IEnumerable<Departamento> Departamentos { get; set; }
    }
}
