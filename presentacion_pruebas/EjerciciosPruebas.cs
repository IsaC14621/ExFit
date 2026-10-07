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
    public sealed class EjerciciosPruebas
    {
        private IConexion conexion;
        private Ejercicio? entidad = null;

        public EjerciciosPruebas()
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
            this.entidad = new Ejercicio()
            {
                Nombre_Ejercicio = "sentadilla",
                Grupo_Muscular = "gluteo",
                Equipo_Requerido = "No",
                Nivel_Dificualtad = "facil"
            };

            this.conexion.Ejercicios!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Ejercicios!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.Equipo_Requerido = "prensa";

            var entry = this.conexion.Entry<Ejercicio>(this.entidad);

            entry.State = EntityState.Modified;

            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Ejercicios!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
