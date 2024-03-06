using Dominio.Common.Enum;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class CentroVenta
    {
        public CentroVenta()
        {
            Premios = new List<Premio>();
        }

        [Key]
        public int Id { get; set; }
        public string Nit { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int ValorPorPunto { get; set; }
        public int CompaniaId { get; set; }
        public virtual Compania? Compania { get; set; }
        public int CiudadId { get; set; }
        public virtual Ciudad? Ciudad { get; set; }
        public int EstadoId { get; set; } = (int)EstadoEnum.Activo;
        public virtual Estado? Estado { get; set; }
        public virtual IEnumerable<Usuario>? Usuarios { get; set; }
        public virtual IEnumerable<Premio>? Premios { get; set; }
    }
}
