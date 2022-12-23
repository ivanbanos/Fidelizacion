using Dominio.Entidades;

namespace FidelizacionApi.Dtos
{
    public class AgregarFidelizadoDto
    {
        public AgregarFidelizadoDto(Fidelizado fidelizado, Guid usuario)
        {
            Fidelizado = fidelizado;
            Usuario = usuario;
        }
        public Fidelizado Fidelizado { get; set; }
        public Guid Usuario { get; set; }
    }
}
