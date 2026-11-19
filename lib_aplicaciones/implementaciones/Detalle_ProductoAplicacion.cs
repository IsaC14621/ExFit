using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.implementaciones
{
    public class Detalle_ProductoAplicacion : IDetalle_ProductoAplicacion
    {
        private IConexion IConexion;

        public Detalle_ProductoAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Detalle_Producto Actualizar(Detalle_Producto entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Detalle_Producto>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Detalle_Producto Borrar(Detalle_Producto entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Detalle_Producto!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Detalle_Producto> Buscar(Detalle_Producto entidad)
        {
            return this.IConexion.Detalle_Producto!
                .Where(x => entidad.id_Venta == 0 ||
                            x.id_Venta == entidad.id_Venta)
                .ToList();
        }

        public List<Detalle_Producto> Consultar()
        {
            return this.IConexion.Detalle_Producto!.Take(5).ToList();
        }

        public Detalle_Producto Insertar(Detalle_Producto entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Detalle_Producto!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Detalle_Producto entidad)
        {
            return entidad.id_Venta <= 0 ||
                entidad.Id_Producto <= 0 ||
                entidad.Cantidad <= 0 ||
                entidad.Subtotal <= 0;
        }
    }
}
