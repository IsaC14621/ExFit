using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.entidades
{
    public class Trabajadores
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? C_c { get; set; }
        public string? Cargo { get; set; }
        public Decimal Salario { get; set; }
        public int Edad { get; set; }

        public ICollection<Cargos>? Cargos { get; set; }
        public ICollection<Asistencia_Trabajadores>? Asistencia_Trabajadores { get; set; }
    }
}
