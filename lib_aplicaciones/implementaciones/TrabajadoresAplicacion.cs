using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.implementaciones
{
    public class TrabajadoresAplicacion : ITrabajadoresAplicacion
    {
        private IConexion IConexion;

        public TrabajadoresAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Trabajadores Actualizar(Trabajadores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Trabajadores>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Trabajadores Borrar(Trabajadores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Trabajadores!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Trabajadores> Buscar(Trabajadores entidad)
        {
            return this.IConexion.Trabajadores!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }

        public List<Trabajadores> Consultar()
        {
            return this.IConexion.Trabajadores!.Take(5).ToList();
        }

        public Trabajadores Insertar(Trabajadores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Trabajadores!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Trabajadores entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.C_c) ||
                string.IsNullOrEmpty(entidad.Cargo) ||
                 entidad.Salario <= 0 ||
                entidad.Edad <= 0;
        }
    }
}