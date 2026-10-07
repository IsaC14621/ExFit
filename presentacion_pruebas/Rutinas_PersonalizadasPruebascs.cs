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
    public sealed class Rutinas_PersonalizadasPruebas
    {
        private IConexion conexion;
        private Rutinas_Personalizadas? entidad = null;

        public Rutinas_PersonalizadasPruebas()
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
            this.entidad = new Rutinas_Personalizadas()
            {
                id_Cliente = 1,
                Nombre_Rutina = "Perdida de grasa",
                Fecha_Inicio = DateTime.Now,
                 Objetivo= "definicion"
            };

            this.conexion.Rutinas_Personalizadas!.Add(this.entidad);
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
            this.entidad!.Objetivo = "tonificacion";

            var entry = this.conexion.Entry<Rutinas_Personalizadas>(this.entidad);

            entry.State = EntityState.Modified;

            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Rutinas_Personalizadas!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
