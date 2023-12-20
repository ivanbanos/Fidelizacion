namespace Dominio.Entidades
{
    public class Redencion
    {
        public int Id { get; set; }
        public int PremioId { get; set; }
        public Premio Premio { get; set; }
        public int FidelizadoId { get; set; }
        public Fidelizado Fidelizado { get; set; }
        public int CentroVentaId { get; set; }
        public DateTime FechaRedencion { get; set; }

        public Redencion(int premioId, int fidelizadoId, int centroVentaId)
        {
            PremioId = premioId;
            FidelizadoId = fidelizadoId;
            CentroVentaId = centroVentaId;
            FechaRedencion = DateTime.Now;
        }

    }
}
