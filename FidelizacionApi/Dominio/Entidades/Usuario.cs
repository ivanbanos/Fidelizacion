using Dominio.Common.Enum;
using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class Usuario
    {
        public Usuario()
        {
        }

        public Usuario(string nombreUsuario, int perfilId, int? centroVentaId)
        {
            NombreUsuario = nombreUsuario;
            PerfilId = perfilId;
            CentroVentaId = centroVentaId;
        }

        [Key]
        public int Id { get; set; }
        public Guid? Guid { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public int PerfilId { get; set; }
        public virtual Perfil? Perfil { get; set; }
        public int EstadoId { get; set; } = (int)EstadoEnum.Activo;
        public virtual Estado? Estado { get; set; }
        public int? CentroVentaId { get; set; }
        public virtual CentroVenta? CentroVenta { get; set; }
    }
}
