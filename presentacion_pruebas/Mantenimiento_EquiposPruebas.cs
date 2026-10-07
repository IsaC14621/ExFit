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
    public sealed class Mantenimiento_EquiposPruebas
    {
        private IConexion conexion;
        private Mantenimiento_Equipos? entidad = null;

        public Mantenimiento_EquiposPruebas()
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
            this.entidad = new Mantenimiento_Equipos()
            {
                Nombre_equipo = "Prensa",
                Fecha_Mantenimiento = DateTime.Now,
                Costo_Servicio = 10000,
               Estado_Actual = "Disponible"
                
            };

            this.conexion.Mantenimiento_Equipos!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Mantenimiento_Equipos!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.Estado_Actual= "Dañado";

            var entry = this.conexion.Entry<Mantenimiento_Equipos>(this.entidad);

            entry.State = EntityState.Modified;

            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Mantenimiento_Equipos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
