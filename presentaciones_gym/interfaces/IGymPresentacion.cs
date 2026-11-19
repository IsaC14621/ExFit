using lib_aplicaciones.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace presentaciones_Gym.interfaces
{
    public interface IGymPresentacion
    {
        Gym Insertar(Gym entidad);
        Gym Actualizar(Gym entidad);
        List<Gym> Consultar();
        List<Gym> Buscar(Gym entidad);
        Gym Borrar(Gym entidad);
    }
}