using lib_aplicaciones.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.interfaces
{
    public interface IGymAplicacion
    {
        Gym Insertar(Gym entidad);
        Gym Actualizar(Gym entidad);
        List<Gym> Consultar();
        List<Gym> Buscar(Gym entidad);
        Gym Borrar(Gym entidad);
    }
}