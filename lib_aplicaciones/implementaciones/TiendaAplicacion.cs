using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.implementaciones
{
    public class TiendaAplicacion : ITiendaAplicacion
    {
        private IConexion IConexion;

        public TiendaAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Tienda Actualizar(Tienda entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Tienda>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Tienda Borrar(Tienda entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Tienda!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Tienda> Buscar(Tienda entidad)
        {
            return this.IConexion.Tienda!
                .Where(x => entidad.id_Producto == 0 ||
                            x.id_Producto == entidad.id_Producto)
                .ToList();
        }

        public List<Tienda> Consultar()
        {
            return this.IConexion.Tienda!.Take(5).ToList();
        }

        public Tienda Insertar(Tienda entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Tienda!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Tienda entidad)
        {
            return entidad.id_Producto <= 0 ||
                entidad.Precio <= 0 ||
                entidad.Cantidad_Disponible < 0 ||
                entidad.Cantidad_Productos < 0 ||
                entidad.Id_Provedor <= 0;
        }
    }
}