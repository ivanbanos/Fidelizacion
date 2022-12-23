namespace FidelizacionApi.Dtos.Contrasena
{
    public class ActualizarContrasenaDto
    {
        public Guid Usuario { get; }
        public string Contrasena { get; }

        public ActualizarContrasenaDto(Guid usuario, string contrasena)
        {
            Usuario = usuario;
            Contrasena = contrasena;
        }
    }
}
