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
    public class LoginsAplicacion : ILoginsAplicacion
    {
        private IConexion IConexion;

        public LoginsAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Logins Actualizar(Logins entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            if (this.IConexion.Logins!.Any(x => x.Usuario == entidad.Usuario && x.Id != entidad.Id))
                throw new Exception("Ese usuario ya tiene un login");

            if (string.IsNullOrEmpty(entidad.Contrasena))
                entidad.Contrasena = this.IConexion.Logins!
                    .AsNoTracking()
                    .Where(x => x.Id == entidad.Id)
                    .Select(x => x.Contrasena)
                    .FirstOrDefault();
            else
                entidad.Contrasena = Cifrar(entidad.Contrasena);

            var entry = this.IConexion!.Entry<Logins>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Logins Borrar(Logins entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Logins!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Logins> Buscar(Logins entidad)
        {
            return this.IConexion.Logins!
                .Where(x => entidad.Usuario == 0 ||
                            x.Usuario == entidad.Usuario)
                .ToList();
        }

        public List<Logins> Consultar()
        {
            return this.IConexion.Logins!.Take(5).ToList();
        }

        public Logins Insertar(Logins entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            if (this.IConexion.Logins!.Any(x => x.Usuario == entidad.Usuario))
                throw new Exception("Ese usuario ya tiene un login");

            if (string.IsNullOrEmpty(entidad.Contrasena))
                throw new Exception("Falta informacion");

            entidad.Contrasena = Cifrar(entidad.Contrasena);

            this.IConexion.Logins!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Logins entidad)
        {
            return entidad.Usuario <= 0;
        }

        private string Cifrar(string clave)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(clave));
            return Convert.ToHexString(bytes);
        }
    }
}