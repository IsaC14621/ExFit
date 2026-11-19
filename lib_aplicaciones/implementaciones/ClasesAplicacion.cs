using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.implementaciones
{
    public class ClasesAplicacion : IClasesAplicacion
    {
        private IConexion IConexion;

        public ClasesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Clases Actualizar(Clases entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Clases>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Clases Borrar(Clases entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Clases!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Clases> Buscar(Clases entidad)
        {
            return this.IConexion.Clases!
                .Where(x => x.Nombre_Clase!.Contains(entidad.Nombre_Clase!))
                .ToList();
        }

        public List<Clases> Consultar()
        {
            return this.IConexion.Clases!.Take(5).ToList();
        }

        public Clases Insertar(Clases entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Clases!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Clases entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre_Clase) ||
                entidad.Tipo_Clase <= 0 ||
                entidad.Fecha == default ||
                entidad.Horario == default;
        }
    }
}

