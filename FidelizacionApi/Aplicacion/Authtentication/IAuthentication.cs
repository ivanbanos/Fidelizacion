using Dominio.Entidades;

namespace Aplicacion.Authtentication
{
    public interface IAuthentication
    {
        string GenerateToken(Usuario usuario);
    }
}
