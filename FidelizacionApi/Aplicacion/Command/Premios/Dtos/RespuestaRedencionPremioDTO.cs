namespace Aplicacion.Command.Premios.Dtos
{
    public class RespuestaRedencionPremioDTO
    {
        public int PuntosConsumidos { get; set; }
        public string DescripcioPremio { get; set; }
        public int CantidadPremio { get; set; }
        public string FechaRedencion { get; set; }
        public string CiudadCentroVenta { get; set; }
        public string NombreCentroVenta { get; set; }
        public string CedulaFidelizado { get; set; }
        public string NombreFidelizado { get; set; }
        public float PuntosRestantes { get; set; }

        public RespuestaRedencionPremioDTO(int puntosConsumidos, string descripcioPremio, int cantidadPremio, 
                                            string fechaRedencion, string ciudadCentroVenta, string nombreCentroVenta, 
                                            string cedulaFidelizado, string nombreFidelizado, float puntosRestantes)
        {
            PuntosConsumidos = puntosConsumidos;
            DescripcioPremio = descripcioPremio;
            CantidadPremio = cantidadPremio;
            FechaRedencion = fechaRedencion;
            CiudadCentroVenta = ciudadCentroVenta;
            NombreCentroVenta = nombreCentroVenta;
            CedulaFidelizado = cedulaFidelizado;
            NombreFidelizado = nombreFidelizado;
            PuntosRestantes = puntosRestantes;
        }
    }
}
