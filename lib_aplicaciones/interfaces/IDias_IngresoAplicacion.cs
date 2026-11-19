using lib_aplicaciones.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.interfaces
{
    public interface IDias_IngresoAplicacion
    {
        Dias_Ingreso Insertar(Dias_Ingreso entidad);
        Dias_Ingreso Actualizar(Dias_Ingreso entidad);
        List<Dias_Ingreso> Consultar();
        List<Dias_Ingreso> Buscar(Dias_Ingreso entidad);
        Dias_Ingreso Borrar(Dias_Ingreso entidad);
    }
}