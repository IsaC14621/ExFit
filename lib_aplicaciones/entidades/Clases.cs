using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_aplicaciones.entidades
{
    public class Clases
    {
        public int Id { get; set; }
        public string? Nombre_Clase { get; set; }
        public int Tipo_Clase { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Horario { get; set; }
        [ForeignKey("Tipo_Clase")] public Tipo_Clases? _Tipo_Clase { get; set; }
       // [ForeignKey("Tipo_Cliente")] public Clientes? _Clientes { get; set; }
        // public ICollection<Tipo_Clases>? Tipo_Clases { get; set; }
    }
}
