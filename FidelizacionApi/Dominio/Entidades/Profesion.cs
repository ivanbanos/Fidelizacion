﻿namespace Dominio.Entidades
{
    public class Profesion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public IEnumerable<InformacionAdicional> InformacionesAdicionales { get; set; }
    }
}
