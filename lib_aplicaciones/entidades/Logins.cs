using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_aplicaciones.entidades
{
    public class Logins
    {
        public int Id { get; set; }
        public int Usuario { get; set; }
        public string? Contrasena { get; set; }
        public bool Activo { get; set; }

        [ForeignKey("Usuario")] public Usuarios? _Usuario { get; set; }
    }
}
