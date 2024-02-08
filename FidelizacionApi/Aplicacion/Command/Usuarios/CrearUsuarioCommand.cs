using MediatR;

namespace Aplicacion.Command.Usuarios
{
    public class CrearUsuarioCommand : IRequest<bool>
    {
        public string NombreUsuario { get; }
        public int Perfil { get; }
        public int? CentroVentaId { get; }

        public CrearUsuarioCommand(string nombreUsuario, 
                        int perfil, 
                        int? centroVentaId)
        {
            NombreUsuario = nombreUsuario;
            Perfil = perfil;
            CentroVentaId = centroVentaId;
        }
    }
}
