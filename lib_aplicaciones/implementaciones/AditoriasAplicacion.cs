using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace lib_aplicaciones.implementaciones
{
    public class AuditoriasAplicacion : IAuditoriasAplicacion
    {
        private IConexion IConexion;

        public AuditoriasAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Auditorias Actualizar(Auditorias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Auditorias>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Auditorias Borrar(Auditorias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Auditorias!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Auditorias> Buscar(Auditorias entidad)
        {
            return this.IConexion.Auditorias!
                .Where(x => x.Accion!.Contains(entidad.Accion!))
                .ToList();
        }

        public List<Auditorias> Consultar()
        {
            return this.IConexion.Auditorias!.Take(5).ToList();
        }

        public Auditorias Insertar(Auditorias entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Auditorias!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Auditorias entidad)
        {
            return string.IsNullOrEmpty(entidad.Accion) ||
                entidad.Usuario <= 0;
        }
    }
}