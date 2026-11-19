using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.implementaciones
{
    public class EjerciciosAplicacion : IEjerciciosAplicacion
    {
        private IConexion IConexion;

        public EjerciciosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Ejercicios Actualizar(Ejercicios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Ejercicios>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Ejercicios Borrar(Ejercicios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Ejercicios!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Ejercicios> Buscar(Ejercicios entidad)
        {
            return this.IConexion.Ejercicios!
                .Where(x => x.Nombre_Ejercicio!.Contains(entidad.Nombre_Ejercicio!))
                .ToList();
        }

        public List<Ejercicios> Consultar()
        {
            return this.IConexion.Ejercicios!.Take(5).ToList();
        }

        public Ejercicios Insertar(Ejercicios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Ejercicios!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Ejercicios entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre_Ejercicio) ||
                string.IsNullOrEmpty(entidad.Grupo_Muscular);
        }
    }
}
