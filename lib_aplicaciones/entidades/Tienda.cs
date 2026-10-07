using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_aplicaciones.entidades
{
    public class Tienda
    {
        public int Id { get; set; }
        public int id_Producto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad_Disponible { get; set; }
        public int Cantidad_Productos { get; set; }
        public int Id_Provedor { get; set; }

        [ForeignKey("id_Producto")] public Productos? _Productos { get; set; }


    }
}
