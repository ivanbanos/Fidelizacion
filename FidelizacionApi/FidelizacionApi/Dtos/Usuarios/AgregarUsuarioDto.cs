namespace FidelizacionApi.Dtos.Usuarios
{
    public class AgregarUsuarioDto
    {
        public string NombreUsuario { get; set; }
        public int Perfil { get; set; }
        public int? CentroVentaId { get; set; }
    }
}
