using lib_aplicaciones.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.interfaces
{
    public interface IMantenimiento_EquiposAplicacion
    {
        Mantenimiento_Equipos Insertar(Mantenimiento_Equipos entidad);
        Mantenimiento_Equipos Actualizar(Mantenimiento_Equipos entidad);
        List<Mantenimiento_Equipos> Consultar();
        List<Mantenimiento_Equipos> Buscar(Mantenimiento_Equipos entidad);
        Mantenimiento_Equipos Borrar(Mantenimiento_Equipos entidad);
    }
}