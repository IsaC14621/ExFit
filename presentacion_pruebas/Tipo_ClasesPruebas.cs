using lib_aplicaciones.entidades;
using Libreria.implementaciones;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pruebas_Unitarias
{
    [TestClass]
    public sealed class Tipo_ClasesPruebas
    {
        private IConexion conexion;
        private Tipo_Clases? entidad = null;

        public Tipo_ClasesPruebas()
        {
            this.conexion = new Conexion();

            // Cadena de conexión a SQL Server
            this.conexion.StringConexion =
                "server=localhost\\Dev;database=ExFit;Integrated Security=True;TrustServerCertificate=true;";
        }

        [TestMethod]
        public void Execute()
        {
            Insertar();
            Consultar();
            Actualizar();
            Borrar();
        }

        public void Insertar()
        {
            this.entidad = new Tipo_Clases()
            {
                Baile_con_el_petalo = true,
                samba_con_el_mozo = false,
                Ex_plotamos = false,
                Huyendo = false
            };

            this.conexion.Tipo_Clases!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Tipo_Clases!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.Huyendo = true;

            var entry = this.conexion.Entry<Tipo_Clases>(this.entidad);

            entry.State = EntityState.Modified;

            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Tipo_Clases!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
