namespace Aplicacion.Query.Companias.Dtos
{
    public class CompaniaDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int VigenciaPuntos { get; set; }
        public int TipoVencimientoId { get; set; }
    }
}
