using lib_aplicaciones.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.interfaces
{
    public interface IDetalle_ProductoAplicacion
    {
        Detalle_Producto Insertar(Detalle_Producto entidad);
        Detalle_Producto Actualizar(Detalle_Producto entidad);
        List<Detalle_Producto> Consultar();
        List<Detalle_Producto> Buscar(Detalle_Producto entidad);
        Detalle_Producto Borrar(Detalle_Producto entidad);
    }
}
