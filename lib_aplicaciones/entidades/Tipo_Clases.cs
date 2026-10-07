using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_aplicaciones.entidades
{
    public class Tipo_Clases
    {
        public int Id { get; set; }
        public bool Baile_con_el_petalo { get; set; }
        public bool samba_con_el_mozo { get; set; }
        public bool Ex_plotamos { get; set; }
        public bool Huyendo { get; set; }
       // [ForeignKey("Clases")] public Clientes? Clases { get; set; }
       public ICollection<Reservas_Clases>? Reservas_Clases { get; set; }
    }
}
