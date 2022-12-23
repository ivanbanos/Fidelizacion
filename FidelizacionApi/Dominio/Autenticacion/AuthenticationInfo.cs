namespace Dominio.Autenticacion
{
    public class AuthenticationInfo
    {
        public string Token { get; set; }
        public int Perfil { get; set; }
        public Guid IdUsuario { get; set; }
        public int IdCompania { get; set; }
        public int IdCentroVenta { get; set; }
    }
}
