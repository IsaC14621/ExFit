using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_aplicaciones.entidades
{
    public class Reservas_Clases
    {
        public int Id { get; set; }
        public int id_Clase { get; set; }
        public int Tipo_Cliente { get; set; }
        public int Tipo_Membresia { get; set; }
        public DateTime Fecha_Reserva { get; set; }
        public bool Asistencia { get; set; }
        [ForeignKey("id_Clase")] public Clases? _Clase { get; set; }

        [ForeignKey("id_Cliente")] public Clientes? _Clientes { get; set; }
        //public ICollection<Clases>? Clases { get; set; }
        //public ICollection<Clientes>? Clientes{ get; set; }
    }
}
