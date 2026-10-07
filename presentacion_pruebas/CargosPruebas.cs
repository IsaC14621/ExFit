using lib_aplicaciones.entidades;
using Libreria.implementaciones;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Pruebas_Unitarias
{
    [TestClass]
    public sealed class CargosPruebas
    {
        private IConexion conexion;
        private Cargos? entidad = null;

        public CargosPruebas()
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
            this.entidad = new Cargos()
            {
                Trabajador = 1,
                Mozo = "Sí",
                Crush = "No",
                Petalo = "No",
                Oficial = "No"
            };

            this.conexion.Cargos!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Cargos!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.Mozo = "Si";
           
            var entry = this.conexion.Entry<Cargos>(this.entidad);

            entry.State = EntityState.Modified;

            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Cargos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
