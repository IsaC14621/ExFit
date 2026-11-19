using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace lib_aplicaciones.implementaciones
{
    public class RolesAplicacion : IRolesAplicacion
    {
        private IConexion IConexion;

        public RolesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Roles Actualizar(Roles entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            if (this.IConexion.Roles!.Any(x => x.Nombre == entidad.Nombre && x.Id != entidad.Id))
                throw new Exception("Ya existe un rol con ese nombre");

            var entry = this.IConexion!.Entry<Roles>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Roles Borrar(Roles entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Roles!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Roles> Buscar(Roles entidad)
        {
            return this.IConexion.Roles!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }

        public List<Roles> Consultar()
        {
            return this.IConexion.Roles!.Take(5).ToList();
        }

        public Roles Insertar(Roles entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            if (this.IConexion.Roles!.Any(x => x.Nombre == entidad.Nombre))
                throw new Exception("Ya existe un rol con ese nombre");

            this.IConexion.Roles!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Roles entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.Descripcion);
        }
    }
}
