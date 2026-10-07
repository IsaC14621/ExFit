using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_aplicaciones.entidades
{
    public class Rutinas_Personalizadas 
    {
        public int Id { get; set; }
        public int id_Cliente { get; set; }
        public string? Nombre_Rutina{ get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public string? Objetivo { get; set; }
        [ForeignKey("id_Cliente")] public Clientes? _Clientes { get; set; }

    }
}
