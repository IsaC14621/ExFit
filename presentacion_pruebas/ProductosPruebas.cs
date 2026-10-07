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
    public sealed class ProductosPruebas
    {
        private IConexion conexion;
        private Productos? entidad = null;

        public ProductosPruebas()
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
            this.entidad = new Productos()
            {
                Id_Cliente = 1,
                Id_Vendedor = 1,
                Nombre_Producto = "CREATINA",
                Fecha_Venta = DateTime.Now,
                Total = 50000
            };

            this.conexion.Productos!.Add(this.entidad);
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
            this.entidad!.Nombre_Producto = "PROTEINA";

            var entry = this.conexion.Entry<Productos>(this.entidad);

            entry.State = EntityState.Modified;

            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Productos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}