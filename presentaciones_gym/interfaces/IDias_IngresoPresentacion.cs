using lib_aplicaciones.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace presentaciones_Dias_Ingreso.interfaces
{
    public interface IDias_IngresoPresentacion
    {
        Dias_Ingreso Insertar(Dias_Ingreso entidad);
        Dias_Ingreso Actualizar(Dias_Ingreso entidad);
        List<Dias_Ingreso> Consultar();
        List<Dias_Ingreso> Buscar(Dias_Ingreso entidad);
        Dias_Ingreso Borrar(Dias_Ingreso entidad);
    }
}
