using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_aplicaciones.entidades
{
    public class Asistencia_Trabajadores
    {
        public int Id { get; set; }
        public int id_Trabajador { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora_Entrada { get; set; }
        public DateTime Hora_Salida { get; set; }

        [ForeignKey("id_Trabajador")] public Trabajadores? id_trabajadores { get; set; }

    }
}
