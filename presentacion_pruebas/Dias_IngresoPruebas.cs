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
    public sealed class Dias_IngresoPruebas
    {
        private IConexion conexion;
        private Dias_Ingreso? entidad = null;

        public Dias_IngresoPruebas()
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
            this.entidad = new Dias_Ingreso()
            {
                Huella = "HUELLA-01",
                Tipo_Membresia = "TusaFit",
                Id_Cliente = 1,
                Hora_ingreso = DateTime.Now,
                Hora_salida = DateTime.Now
            };

            this.conexion.Dias_Ingreso!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Dias_Ingreso!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.Tipo_Membresia = "NoMasEx";

            var entry = this.conexion.Entry<Dias_Ingreso>(this.entidad);

            entry.State = EntityState.Modified;

            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Dias_Ingreso!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
