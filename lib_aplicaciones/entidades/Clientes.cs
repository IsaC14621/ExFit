using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.entidades
{
    public class Clientes
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? C_c { get; set; }
        public int Membresia { get; set; }
        public int Edad { get; set; }
        public string? Huella { get; set; }

        public ICollection<Membresias>? Membresias { get; set; }
        public ICollection<Valoraciones_Medicas>? Valoraciones_Medicas { get; set; }
        public ICollection<Dias_Ingreso>? Dias_Ingreso { get; set; }
        public ICollection<Casilleros>? Casilleros { get; set; }
        public ICollection<Reservas_Clases>? Reservas_Clases { get; set; }
        public ICollection<Rutinas_Personalizadas>? Rutinas_Personalizadas { get; set; }
        public ICollection<Productos>? Productos { get; set; }

    }
}
