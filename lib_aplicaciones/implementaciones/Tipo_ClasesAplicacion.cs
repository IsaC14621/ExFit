using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.implementaciones
{
    public class Tipo_ClasesAplicacion : ITipo_ClasesAplicacion
    {
        private IConexion IConexion;

        public Tipo_ClasesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Tipo_Clases Actualizar(Tipo_Clases entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Tipo_Clases>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Tipo_Clases Borrar(Tipo_Clases entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Tipo_Clases!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Tipo_Clases> Buscar(Tipo_Clases entidad)
        {
            return this.IConexion.Tipo_Clases!
                .Where(x => entidad.Id == 0 ||
                            x.Id == entidad.Id)
                .ToList();
        }

        public List<Tipo_Clases> Consultar()
        {
            return this.IConexion.Tipo_Clases!.Take(5).ToList();
        }

        public Tipo_Clases Insertar(Tipo_Clases entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Tipo_Clases!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Tipo_Clases entidad)
        {
            return false;
        }
    }
}

