using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.implementaciones
{
    public class PagosAplicacion : IPagosAplicacion
    {
        private IConexion IConexion;

        public PagosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Pagos Actualizar(Pagos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Pagos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Pagos Borrar(Pagos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Pagos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Pagos> Buscar(Pagos entidad)
        {
            return this.IConexion.Pagos!
                .Where(x => entidad.Id_Membresia == 0 ||
                            x.Id_Membresia == entidad.Id_Membresia)
                .ToList();
        }

        public List<Pagos> Consultar()
        {
            return this.IConexion.Pagos!.Take(5).ToList();
        }

        public Pagos Insertar(Pagos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Pagos!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Pagos entidad)
        {
            return entidad.Id_Membresia <= 0 ||
                !this.IConexion.Membresias!.Any(x => x.Id == entidad.Id_Membresia) ||
                entidad.Valor_a_pagar <= 0 ||
                entidad.Fecha_Pago == default ||
                string.IsNullOrEmpty(entidad.Metodo_Pago);
        }
    }
}