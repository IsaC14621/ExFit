using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.implementaciones
{
    public class Mantenimiento_EquiposAplicacion : IMantenimiento_EquiposAplicacion
    {
        private IConexion IConexion;

        public Mantenimiento_EquiposAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Mantenimiento_Equipos Actualizar(Mantenimiento_Equipos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Mantenimiento_Equipos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Mantenimiento_Equipos Borrar(Mantenimiento_Equipos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Mantenimiento_Equipos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Mantenimiento_Equipos> Buscar(Mantenimiento_Equipos entidad)
        {
            return this.IConexion.Mantenimiento_Equipos!
                .Where(x => x.Nombre_equipo!.Contains(entidad.Nombre_equipo!))
                .ToList();
        }

        public List<Mantenimiento_Equipos> Consultar()
        {
            return this.IConexion.Mantenimiento_Equipos!.Take(5).ToList();
        }

        public Mantenimiento_Equipos Insertar(Mantenimiento_Equipos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Mantenimiento_Equipos!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Mantenimiento_Equipos entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre_equipo) ||
                entidad.Fecha_Mantenimiento == default ||
                entidad.Costo_Servicio <= 0 ||
                string.IsNullOrEmpty(entidad.Estado_Actual);
        }
    }
}
