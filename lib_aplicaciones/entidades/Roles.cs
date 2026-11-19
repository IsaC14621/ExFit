using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace lib_aplicaciones.entidades
{
    public class Roles
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
    }
}
