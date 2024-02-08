using MediatR;

namespace Aplicacion.Command.Companias
{
    public class ActualizarCompaniaCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int VigenciaPuntos { get; set; }
        public int TipoVencimientoId { get; set; }

        public ActualizarCompaniaCommand(int id, 
                                    string nombre, 
                                    int vigenciaPuntos, 
                                    int tipoVencimientoId)
        {
            Id = id;
            Nombre = nombre;
            VigenciaPuntos = vigenciaPuntos;
            TipoVencimientoId = tipoVencimientoId;
        }
    }
}
