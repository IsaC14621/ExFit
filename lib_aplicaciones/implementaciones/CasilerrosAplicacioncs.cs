using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.implementaciones
{
    public class CasillerosAplicacion : ICasillerosAplicacion
    {
        private IConexion IConexion;

        public CasillerosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Casilleros Actualizar(Casilleros entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Casilleros>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Casilleros Borrar(Casilleros entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Casilleros!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Casilleros> Buscar(Casilleros entidad)
        {
            return this.IConexion.Casilleros!
                .Where(x => x.Estado!.Contains(entidad.Estado!))
                .ToList();
        }

        public List<Casilleros> Consultar()
        {
            return this.IConexion.Casilleros!.Take(5).ToList();
        }

        public Casilleros Insertar(Casilleros entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Casilleros!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

   


private bool Validar(Casilleros entidad)
        {
            return entidad.Numero_Casillero <= 0 ||
                entidad.id_Cliente <= 0 ||
                string.IsNullOrEmpty(entidad.Estado);
        }
    }
}