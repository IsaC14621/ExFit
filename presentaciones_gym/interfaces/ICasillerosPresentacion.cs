using lib_aplicaciones.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace presentaciones_Casilleros.interfaces
{
    public interface ICasillerosPresentacion
    {
        Casilleros Insertar(Casilleros entidad);
        Casilleros Actualizar(Casilleros entidad);
        List<Casilleros> Consultar();
        List<Casilleros> Buscar(Casilleros entidad);
        Casilleros Borrar(Casilleros entidad);
    }
}
