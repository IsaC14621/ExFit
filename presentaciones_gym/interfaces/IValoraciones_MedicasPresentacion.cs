using lib_aplicaciones.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace presentaciones_Valoraciones_Medicas.interfaces
{
    public interface IValoraciones_MedicasPresentacion
    {
        Valoraciones_Medicas Insertar(Valoraciones_Medicas entidad);
        Valoraciones_Medicas Actualizar(Valoraciones_Medicas entidad);
        List<Valoraciones_Medicas> Consultar();
        List<Valoraciones_Medicas> Buscar(Valoraciones_Medicas entidad);
        Valoraciones_Medicas Borrar(Valoraciones_Medicas entidad);
    }
}