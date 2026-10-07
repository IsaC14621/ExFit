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
    public sealed class PagosPruebas
    {
        private IConexion conexion;
        private Pagos? entidad = null;

        public PagosPruebas()
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
            this.entidad = new Pagos()
            {
                Id_Membresia = 1,
                Valor_a_pagar = 500000,
                Fecha_Pago = DateTime.Now,
                Metodo_Pago = "TRANSFERENCIA"
            };

            this.conexion.Pagos!.Add(this.entidad);
            this.conexion.SaveChanges();
        }

        public void Consultar()
        {
            var lista = this.conexion.Pagos!.ToList();

            if (lista.Count <= 0)
                throw new Exception("Lista vacía");
        }

        private void Actualizar()
        {
            this.entidad!.Metodo_Pago = "EFECTIVO";

            var entry = this.conexion.Entry<Pagos>(this.entidad);

            entry.State = EntityState.Modified;

            this.conexion.SaveChanges();
        }

        private void Borrar()
        {
            this.conexion.Pagos!.Remove(this.entidad!);
            this.conexion.SaveChanges();
        }
    }
}
