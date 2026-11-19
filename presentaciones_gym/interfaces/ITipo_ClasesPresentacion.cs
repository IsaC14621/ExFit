using lib_aplicaciones.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace presentaciones_Tipo_Clases.interfaces
{
    public interface ITipo_ClasesPresentacion
    {
        Tipo_Clases Insertar(Tipo_Clases entidad);
        Tipo_Clases Actualizar(Tipo_Clases entidad);
        List<Tipo_Clases> Consultar();
        List<Tipo_Clases> Buscar(Tipo_Clases entidad);
        Tipo_Clases Borrar(Tipo_Clases entidad);
    }
}
