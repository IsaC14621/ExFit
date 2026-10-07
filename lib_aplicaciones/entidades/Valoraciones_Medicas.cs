using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_aplicaciones.entidades
{
    public class Valoraciones_Medicas
    {
        public int Id { get; set; }
        public int Id_Cliente { get; set; }
        public Decimal Peso { get; set; }
        public Decimal Estatura { get; set; }
        public Decimal IMC { get; set; }
        public DateTime Fecha_Evaluacion { get; set; }

        [ForeignKey("Id_Cliente")] public Clientes? _Clientes { get; set; }

    }
}
