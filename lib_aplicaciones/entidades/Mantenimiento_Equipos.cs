using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.entidades
{
    public class Mantenimiento_Equipos
    {
        public int Id { get; set; }
        public string? Nombre_equipo { get; set; }
        public DateTime Fecha_Mantenimiento { get; set; }
        public Decimal Costo_Servicio{ get; set; }
        public string? Estado_Actual { get; set; }

    }
}
