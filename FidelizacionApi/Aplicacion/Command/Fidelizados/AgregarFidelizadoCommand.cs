using Dominio.Entidades;
using MediatR;

namespace Aplicacion.Command.Fidelizados
{
    public class AgregarFidelizadoCommand : IRequest<bool>
    {
        public string Documento { get; set; }
        public int TipoDocumentoId { get; set; }
        public string Nombre { get; set; }
        public float PorcentajePuntos { get; set; }
        public int CentroVentaId { get; set; }
        public string? Telefono { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public int? Estrato { get; set; }
        public int? NumeroHijos { get; set; }
        public int SexoId { get; set; }
        public int CiudadId { get; set; }
        public int? ProfesionId { get; set; }
        public Guid Usuario { get; }

        public AgregarFidelizadoCommand(string documento, 
            int tipoDocumentoId, 
            string nombre, 
            float porcentajePuntos, 
            int centroVentaId, 
            string telefono, 
            string celular, 
            string direccion, 
            int? estrato, 
            int? numeroHijos, 
            int sexoId, 
            int ciudadId, 
            int? profesionId, 
            Guid usuario)
        {
            Documento = documento;
            TipoDocumentoId = tipoDocumentoId;
            Nombre = nombre;
            PorcentajePuntos = porcentajePuntos;
            CentroVentaId = centroVentaId;
            Telefono = telefono;
            Celular = celular;
            Direccion = direccion;
            Estrato = estrato;
            NumeroHijos = numeroHijos;
            SexoId = sexoId;
            CiudadId = ciudadId;
            ProfesionId = profesionId;
            Usuario = usuario;
        }
    }
}
