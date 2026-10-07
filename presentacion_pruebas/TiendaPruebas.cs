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
    public sealed class TiendaPruebas
    {
        private IConexion conexion;
        private Tienda? entidad = null;

        public TiendaPruebas()
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
            this.entidad = new Tienda()
            {
                id_Producto = 1,
                Precio = 30000,
                Cantidad_Disponible = 15,
                Cantidad_Productos = 20,
                Id_Provedor = 5
            };

            this.conexion.Tienda!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Tienda!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.Cantidad_Productos = 15;

            var entry = this.conexion.Entry<Tienda>(this.entidad);

            entry.State = EntityState.Modified;

            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Tienda!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
