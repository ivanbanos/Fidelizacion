﻿namespace Aplicacion.Query.CentroVentas.Dtos
{
    public class CentroVentaDto
    {
        public int Id { get; set; }
        public string Nit { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int ValorPorPunto { get; set; }
    }
}
