using lib_aplicaciones.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace presentaciones_Membresias.interfaces
{
    public interface IMembresiasPresentacion
    {
        Membresias Insertar(Membresias entidad);
        Membresias Actualizar(Membresias entidad);
        List<Membresias> Consultar();
        List<Membresias> Buscar(Membresias entidad);
        Membresias Borrar(Membresias entidad);
    }
}
