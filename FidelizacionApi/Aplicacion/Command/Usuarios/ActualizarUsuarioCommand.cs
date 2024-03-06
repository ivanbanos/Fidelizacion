using MediatR;

namespace Aplicacion.Command.Usuarios
{
    public class ActualizarUsuarioCommand : IRequest<bool>
    {
        public Guid Guid { get; set; }
        public string NombreUsuario { get; }
        public int PerfilId { get; }
        public int? CentroVentaId { get; }

        public ActualizarUsuarioCommand(Guid guid, 
                        string nombreUsuario,
                        int perfilId,
                        int centroVentaId)
        {
            Guid = guid;
            PerfilId = perfilId;
            CentroVentaId = centroVentaId;
        }
    }
}