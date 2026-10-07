using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_aplicaciones.entidades
{
    public class Detalle_Producto
    {
        public int Id { get; set; }
        public int id_Venta { get; set; }
        public int Id_Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }

        [ForeignKey("Id_Producto")] public Productos? _Producto { get; set; }
    }
}
