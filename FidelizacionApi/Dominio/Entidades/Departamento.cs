﻿namespace Dominio.Entidades
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public int PaisId { get; set; }
        public virtual Pais Pais { get; set; }
        public virtual IEnumerable<Ciudad> Ciudades { get; set; }
    }
}
