using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_aplicaciones.entidades
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Correo { get; set; }
        public bool Activo { get; set; }
        public int Rol { get; set; }

        [ForeignKey("Rol")] public Roles? _Rol { get; set; }
    }
}
