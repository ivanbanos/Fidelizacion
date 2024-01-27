using MediatR;

namespace Aplicacion.Command.Fidelizados
{
    public class ActualizarFidelizadoCommand : IRequest<bool>
    {
        public int Id { get; }
        public string Nombre { get; set; }
        public float PorcentajePuntos { get; set; }
        public string? Telefono { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public int? Estrato { get; set; }
        public int? NumeroHijos { get; set; }
        public int SexoId { get; set; }
        public int CiudadId { get; set; }
        public int? ProfesionId { get; set; }

        public ActualizarFidelizadoCommand(int id,
            string nombre,
            float porcentajePuntos,
            string telefono,
            string celular,
            string direccion,
            int? estrato,
            int? numeroHijos,
            int sexoId,
            int ciudadId,
            int? profesionId)
        {
            Id = id;
            Nombre = nombre;
            PorcentajePuntos = porcentajePuntos;
            Telefono = telefono;
            Celular = celular;
            Direccion = direccion;
            Estrato = estrato;
            NumeroHijos = numeroHijos;
            SexoId = sexoId;
            CiudadId = ciudadId;
            ProfesionId = profesionId;
        }
    }
}
