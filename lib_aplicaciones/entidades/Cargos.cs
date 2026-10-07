using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_aplicaciones.entidades
{
    public class Cargos
    {
        public int Id { get; set; }
        public int Trabajador{ get; set; }
        public string? Mozo { get; set; }
        public string? Crush { get; set; }
        public string? Petalo { get; set; }
        public string? Oficial { get; set; }

        [ForeignKey("Trabajador")] public Trabajadores? _Trabajador { get; set; }

    }
}
