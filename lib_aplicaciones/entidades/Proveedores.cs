using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.entidades
{
    public class Proveedores
    {
        public int Id { get; set; }
        public int Id_Tienda{ get; set; }
        public string Nombre_Empresa { get; set; }
        public string Tipo_Producto { get; set; }
        public string? Direccion { get; set; }
    }
}
