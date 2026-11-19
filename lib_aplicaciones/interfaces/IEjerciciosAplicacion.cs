using lib_aplicaciones.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.interfaces
{
    public interface IEjerciciosAplicacion
    {
        Ejercicios Insertar(Ejercicios entidad);
        Ejercicios Actualizar(Ejercicios entidad);
        List<Ejercicios> Consultar();
        List<Ejercicios> Buscar(Ejercicios entidad);
        Ejercicios Borrar(Ejercicios entidad);
    }
}
