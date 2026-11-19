using lib_aplicaciones.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace presentaciones_Rutinas_Personalizadas.interfaces
{
    public interface IRutinas_PersonalizadasPresentacion
    {
        Rutinas_Personalizadas Insertar(Rutinas_Personalizadas entidad);
        Rutinas_Personalizadas Actualizar(Rutinas_Personalizadas entidad);
        List<Rutinas_Personalizadas> Consultar();
        List<Rutinas_Personalizadas> Buscar(Rutinas_Personalizadas entidad);
        Rutinas_Personalizadas Borrar(Rutinas_Personalizadas entidad);
    }
}
