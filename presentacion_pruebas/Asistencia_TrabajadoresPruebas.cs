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
    public sealed class Asistencia_TrabajadoresPruebas
    {
        private IConexion conexion;
        private Asistencia_Trabajadores? entidad = null;

        public Asistencia_TrabajadoresPruebas()
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
            this.entidad = new Asistencia_Trabajadores()
            {
                id_Trabajador = 1,
                Fecha = DateTime.Now,
                Hora_Entrada = DateTime.Now,
                Hora_Salida = DateTime.Now
                
            };


            this.conexion.Asistencia_Trabajadores!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Asistencia_Trabajadores!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.Hora_Entrada = DateTime.Now;

            var entry = this.conexion.Entry<Asistencia_Trabajadores>(this.entidad);

            entry.State = EntityState.Modified;

            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Asistencia_Trabajadores!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}


