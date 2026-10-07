using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_aplicaciones.entidades
{
    public class Dias_Ingreso
    {
        public int Id { get; set; }
        public string? Huella { get; set; }
        public string? Tipo_Membresia { get; set; }
        public int Id_Cliente { get; set; }
        public DateTime Hora_ingreso { get; set; }
        public DateTime Hora_salida { get; set; }

        [ForeignKey("Id_Cliente")] public Clientes? _Clientes { get; set; }

    }
}
