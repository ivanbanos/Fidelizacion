﻿namespace Dominio.Entidades
{
    public class Perfil
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public virtual IEnumerable<Usuario> Usuarios { get; set; }

    }
}
