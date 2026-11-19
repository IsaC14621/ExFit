using lib_aplicaciones.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.interfaces
{
    public interface IMembresiasAplicacion
    {
        Membresias Insertar(Membresias entidad);
        Membresias Actualizar(Membresias entidad);
        List<Membresias> Consultar();
        List<Membresias> Buscar(Membresias entidad);
        Membresias Borrar(Membresias entidad);
    }
}
