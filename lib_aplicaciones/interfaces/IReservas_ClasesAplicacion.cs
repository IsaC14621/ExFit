using lib_aplicaciones.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.interfaces
{
    public interface IReservas_ClasesAplicacion
    {
        Reservas_Clases Insertar(Reservas_Clases entidad);
        Reservas_Clases Actualizar(Reservas_Clases entidad);
        List<Reservas_Clases> Consultar();
        List<Reservas_Clases> Buscar(Reservas_Clases entidad);
        Reservas_Clases Borrar(Reservas_Clases entidad);
    }
}

