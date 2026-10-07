using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_aplicaciones.entidades
{
    public class Pagos
    {
        public int Id { get; set; }
        public int Id_Membresia { get; set; }
        public Decimal Valor_a_pagar { get; set; }
        public DateTime Fecha_Pago { get; set; }
        public string? Metodo_Pago { get; set; }

        [ForeignKey("Id_Membresia")] public Membresias? Membresias { get; set; }

    }
}
