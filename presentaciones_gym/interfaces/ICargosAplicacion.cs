using lib_aplicaciones.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace presentaciones_Cargos.interfaces
{
    public interface ICargosPresentacion
    {
        Cargos Insertar(Cargos entidad);
        Cargos Actualizar(Cargos entidad);
        List<Cargos> Consultar();
        List<Cargos> Buscar(Cargos entidad);
        Cargos Borrar(Cargos entidad);
    }
}
