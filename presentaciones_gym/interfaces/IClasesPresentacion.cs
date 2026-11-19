using lib_aplicaciones.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace presentaciones_Clases.interfaces
{
    public interface IClasesPresentacion
    {
        Clases Insertar(Clases entidad);
        Clases Actualizar(Clases entidad);
        List<Clases> Consultar();
        List<Clases> Buscar(Clases entidad);
        Clases Borrar(Clases entidad);
    }
}
