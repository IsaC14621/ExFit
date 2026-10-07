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
    public sealed class TrabajadoresPruebas
    {
        private IConexion conexion;
        private Trabajadores? entidad = null;

        public TrabajadoresPruebas()
        {
            this.conexion = new Conexion();

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
            this.entidad = new Trabajadores()
            {
                Nombre = "Juan",
                C_c = "230",
                Cargo = "Mozo",
                Salario = 10000,
                Edad = 30
            };

            this.conexion.Trabajadores!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Trabajadores!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.Nombre = "Luisa";

            var entry = this.conexion.Entry<Trabajadores>(this.entidad);

            entry.State = EntityState.Modified;

            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Trabajadores!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

