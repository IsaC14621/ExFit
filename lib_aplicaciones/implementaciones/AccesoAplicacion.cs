using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace lib_aplicaciones.implementaciones
{
    public class AccesoAplicacion : IAccesoAplicacion
    {
        private IConexion IConexion;

        public AccesoAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Usuarios Ingresar(Credenciales entidad)
        {
            if (string.IsNullOrEmpty(entidad.Correo) ||
                string.IsNullOrEmpty(entidad.Contrasena))
                throw new Exception("Falta informacion");

            var hash = Convert.ToHexString(
                SHA256.HashData(Encoding.UTF8.GetBytes(entidad.Contrasena)));

            var usuario = this.IConexion.Usuarios!
                .Include(x => x._Rol)
                .FirstOrDefault(x => x.Correo == entidad.Correo && x.Activo);

            if (usuario == null)
                throw new Exception("Correo o contrasena incorrectos");

            var login = this.IConexion.Logins!
                .FirstOrDefault(x => x.Usuario == usuario.Id &&
                                     x.Activo &&
                                     x.Contrasena == hash);

            if (login == null)
                throw new Exception("Correo o contrasena incorrectos");

            return usuario;
        }
    }
}