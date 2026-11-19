using lib_aplicaciones.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace presentaciones_Trabajadores.interfaces
{
    public interface ITrabajadoresPresentacion
    {
        Trabajadores Insertar(Trabajadores entidad);
        Trabajadores Actualizar(Trabajadores entidad);
        List<Trabajadores> Consultar();
        List<Trabajadores> Buscar(Trabajadores entidad);
        Trabajadores Borrar(Trabajadores entidad);
    }
}


