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
    public sealed class Valoraciones_MedicasPruebas
    {
        private IConexion conexion;
        private Valoraciones_Medicas? entidad = null;

        public Valoraciones_MedicasPruebas()
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
            this.entidad = new Valoraciones_Medicas()
            {
                Id_Cliente = 1,
                Peso = 50m,
                Estatura = 1.60m,
                IMC = 99.99m,
                Fecha_Evaluacion = DateTime.Now
            };

            this.conexion.Valoraciones_Medicas!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Valoraciones_Medicas!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.Peso = 45;

            var entry = this.conexion.Entry<Valoraciones_Medicas>(this.entidad);

            entry.State = EntityState.Modified;

            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Valoraciones_Medicas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
