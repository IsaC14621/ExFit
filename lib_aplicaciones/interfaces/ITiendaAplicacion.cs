using lib_aplicaciones.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.interfaces
{
    public interface ITiendaAplicacion
    {
        Tienda Insertar(Tienda entidad);
        Tienda Actualizar(Tienda entidad);
        List<Tienda> Consultar();
        List<Tienda> Buscar(Tienda entidad);
        Tienda Borrar(Tienda entidad);
    }
}
