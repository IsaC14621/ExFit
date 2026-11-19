using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.implementaciones
{
    public class MembresiasAplicacion : IMembresiasAplicacion
    {
        private IConexion IConexion;

        public MembresiasAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Membresias Actualizar(Membresias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Membresias>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Membresias Borrar(Membresias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Membresias!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Membresias> Buscar(Membresias entidad)
        {
            return this.IConexion.Membresias!
                .Where(x => entidad.Cliente == 0 ||
                            x.Cliente == entidad.Cliente)
                .ToList();
        }

        public List<Membresias> Consultar()
        {
            return this.IConexion.Membresias!.Take(5).ToList();
        }

        public Membresias Insertar(Membresias entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Membresias!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Membresias entidad)
        {
            return entidad.Cliente <= 0 ||
                !this.IConexion.Clientes!.Any(x => x.Id == entidad.Cliente);
        }
    }
}
