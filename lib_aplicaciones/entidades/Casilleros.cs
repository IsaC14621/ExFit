using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_aplicaciones.entidades
{
    public class Casilleros
    {
        public int Id { get; set; }
        public int id_Casillero { get; set; }
        public int Numero_Casillero { get; set; }
        public int id_Cliente { get; set; }
        public string? Estado { get; set; }
        [ForeignKey("id_Cliente")] public Clientes? _Clientes { get; set; }

    }
}
