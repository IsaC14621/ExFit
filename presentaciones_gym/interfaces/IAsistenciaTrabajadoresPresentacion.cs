using lib_aplicaciones.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace presentaciones_AsistenciaTrabajadores.interfaces
{
    public interface IAsistenciaTrabajadoresPresentacion
    {
        AsistenciaTrabajadores Insertar(AsistenciaTrabajadores entidad);
        AsistenciaTrabajadores Actualizar(AsistenciaTrabajadores entidad);
        List<AsistenciaTrabajadores> Consultar();
        List<AsistenciaTrabajadores> Buscar(AsistenciaTrabajadores entidad);
        AsistenciaTrabajadores Borrar(AsistenciaTrabajadores entidad);
    }
}

