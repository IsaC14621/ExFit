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
    public sealed class CasillerosPruebas
    {
        private IConexion conexion;
        private Casilleros? entidad = null;

        public CasillerosPruebas()
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
            this.entidad = new Casilleros()
            {
                id_Casillero = 1,
                Numero_Casillero = 1,
                id_Cliente = 1,
                Estado = "ocupado"
            };

            this.conexion.Casilleros!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Casilleros!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.Estado = "disponible";

            var entry = this.conexion.Entry<Casilleros>(this.entidad);

            entry.State = EntityState.Modified;

            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Casilleros!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
