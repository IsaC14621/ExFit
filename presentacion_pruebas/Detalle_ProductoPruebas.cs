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
    public sealed class Detalle_ProductoPruebas
    {
        private IConexion conexion;
        private Detalle_Producto? entidad = null;

        public Detalle_ProductoPruebas()
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
            this.entidad = new Detalle_Producto()
            {
                id_Venta = 1,
                Id_Producto = 1,
                Cantidad = 20,
                Subtotal = 50000
            };

            this.conexion.Detalle_Producto!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Detalle_Producto!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.Cantidad = 30;

            var entry = this.conexion.Entry<Detalle_Producto>(this.entidad);

            entry.State = EntityState.Modified;

            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Detalle_Producto!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
