using lib_aplicaciones.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.interfaces
{
    public interface IRutinas_PersonalizadasAplicacion
    {
        Rutinas_Personalizadas Insertar(Rutinas_Personalizadas entidad);
        Rutinas_Personalizadas Actualizar(Rutinas_Personalizadas entidad);
        List<Rutinas_Personalizadas> Consultar();
        List<Rutinas_Personalizadas> Buscar(Rutinas_Personalizadas entidad);
        Rutinas_Personalizadas Borrar(Rutinas_Personalizadas entidad);
    }
}
