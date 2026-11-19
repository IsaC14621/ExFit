using lib_aplicaciones.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.interfaces
{
    public interface IProductosAplicacion
    {
        Productos Insertar(Productos entidad);
        Productos Actualizar(Productos entidad);
        List<Productos> Consultar();
        List<Productos> Buscar(Productos entidad);
        Productos Borrar(Productos entidad);
    }
}
