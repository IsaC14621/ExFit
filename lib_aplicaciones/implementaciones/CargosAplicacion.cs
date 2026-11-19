using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.implementaciones
{
    public class CargosAplicacion : ICargosAplicacion
    {
        private IConexion IConexion;

        public CargosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Cargos Actualizar(Cargos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Cargos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Cargos Borrar(Cargos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Cargos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Cargos> Buscar(Cargos entidad)
        {
            return this.IConexion.Cargos!
                .Where(x => entidad.Trabajador == 0 ||
                            x.Trabajador == entidad.Trabajador)
                .ToList();
        }

        public List<Cargos> Consultar()
        {
            return this.IConexion.Cargos!.Take(5).ToList();
        }

        public Cargos Insertar(Cargos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Cargos!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Cargos entidad)
        {
            return entidad.Trabajador <= 0 ||
                string.IsNullOrEmpty(entidad.Mozo) ||
                string.IsNullOrEmpty(entidad.Crush) ||
                string.IsNullOrEmpty(entidad.Petalo) ||
                string.IsNullOrEmpty(entidad.Oficial);
        }
    }
}
