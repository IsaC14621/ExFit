using lib_aplicaciones.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.interfaces
{
    public interface IClasesAplicacion
    {
        Clases Insertar(Clases entidad);
        Clases Actualizar(Clases entidad);
        List<Clases> Consultar();
        List<Clases> Buscar(Clases entidad);
        Clases Borrar(Clases entidad);
    }
}
