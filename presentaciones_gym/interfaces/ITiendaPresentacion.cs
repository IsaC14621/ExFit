using lib_aplicaciones.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace presentaciones_Tienda.interfaces
{
    public interface ITiendaPresentacion
    {
        Tienda Insertar(Tienda entidad);
        Tienda Actualizar(Tienda entidad);
        List<Tienda> Consultar();
        List<Tienda> Buscar(Tienda entidad);
        Tienda Borrar(Tienda entidad);
    }
}