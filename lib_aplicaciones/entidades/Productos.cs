using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_aplicaciones.entidades
{
    public class Productos
    {
        public int Id { get; set; }
        public int Id_Cliente { get; set; }
        public int Id_Vendedor { get; set; }
        public string  Nombre_Producto { get; set; }
        public DateTime Fecha_Venta { get; set; }
        public decimal Total { get; set; }

        [ForeignKey("Id_Cliente")] public Clientes? _Clientes { get; set; }

        public ICollection<Tienda>? Tienda { get; set; }
        public ICollection<Detalle_Producto>? Detalle_Producto { get; set; }

    }
}
