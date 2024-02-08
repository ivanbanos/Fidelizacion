using MediatR;

namespace Aplicacion.Command.Companias
{
    public class AgregarCompaniaCommand : IRequest<bool>
    {
        public string Nombre { get; set; }
        public int VigenciaPuntos { get; set; }
        public int TipoVencimientoId { get; set; }

        public AgregarCompaniaCommand(string nombre, 
                                int vigenciaPuntos, 
                                int tipoVencimientoId)
        {
            Nombre = nombre;
            VigenciaPuntos = vigenciaPuntos;
            TipoVencimientoId = tipoVencimientoId;
        }
    }
}
