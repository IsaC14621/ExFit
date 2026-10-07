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
    public sealed class ProveedoresPruebas
    {
        private IConexion conexion;
        private Proveedores? entidad = null;

        public ProveedoresPruebas()
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
            this.entidad = new Proveedores()
            {
                Id_Tienda = 1,
                Nombre_Empresa = "Suplementos Fit Colombia",
                Tipo_Producto = "Proteinas",
                Direccion= "Calle 100"
                
            };

            this.conexion.Proveedores!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Proveedores!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.Tipo_Producto= "Barras de Proteina";

            var entry = this.conexion.Entry<Proveedores>(this.entidad);

            entry.State = EntityState.Modified;

            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Proveedores!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}

