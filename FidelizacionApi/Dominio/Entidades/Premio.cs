using Dominio.Common.Enum;

namespace Dominio.Entidades
{
    public class Premio
    {
        public int Id { get; set; }
        public Guid? Guid { get; set; }
        public string Nombre { get; set; }
        public int Puntos { get; set; }
        public float Precio { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int EstadoId { get; set; }
        public int CompaniaId { get; set; }
        public virtual Compania Compania { get; set; }

        public virtual IEnumerable<Redencion> Redenciones { get; set; }

        public Premio()
            {
                Guid = System.Guid.NewGuid();
                EstadoId = (int)EstadoEnum.Activo;
                FechaInicio = DateTime.Now;
            }
        }
}
