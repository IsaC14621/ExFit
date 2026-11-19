using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.implementaciones
{
    public class AsistenciaTrabajadoresAplicacion : IAsistenciaTrabajadoresAplicacion
    {
        private IConexion IConexion;

        public AsistenciaTrabajadoresAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public AsistenciaTrabajadores Actualizar(AsistenciaTrabajadores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<AsistenciaTrabajadores>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public AsistenciaTrabajadores Borrar(AsistenciaTrabajadores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.AsistenciaTrabajadores!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<AsistenciaTrabajadores> Buscar(AsistenciaTrabajadores entidad)
        {
            return this.IConexion.AsistenciaTrabajadores!
                .Where(x => entidad.id_Trabajador == 0 ||
                            x.id_Trabajador == entidad.id_Trabajador)
                .ToList();
        }

        public List<AsistenciaTrabajadores> Consultar()
        {
            return this.IConexion.AsistenciaTrabajadores!.Take(5).ToList();
        }

        public AsistenciaTrabajadores Insertar(AsistenciaTrabajadores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.AsistenciaTrabajadores!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(AsistenciaTrabajadores entidad)
        {
            return entidad.id_Trabajador <= 0 ||
                entidad.Fecha == default ||
                entidad.Hora_Entrada == default ||
                entidad.Hora_Salida == default;
        }
    }
}
