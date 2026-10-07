using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.entidades
{
    public class Ejercicio
    {
        public int Id { get; set; }
        public string? Nombre_Ejercicio{ get; set; }
        public string? Grupo_Muscular { get; set; }
        public string? Equipo_Requerido { get; set; }
        public string? Nivel_Dificualtad { get; set; }

    }
}
