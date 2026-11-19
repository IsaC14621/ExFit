using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.implementaciones
{
    public class Dias_IngresoAplicacion : IDias_IngresoAplicacion
    {
        private IConexion IConexion;

        public Dias_IngresoAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Dias_Ingreso Actualizar(Dias_Ingreso entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Dias_Ingreso>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Dias_Ingreso Borrar(Dias_Ingreso entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Dias_Ingreso!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Dias_Ingreso> Buscar(Dias_Ingreso entidad)
        {
            return this.IConexion.Dias_Ingreso!
                .Where(x => x.Tipo_Membresia!.Contains(entidad.Tipo_Membresia!))
                .ToList();
        }

        public List<Dias_Ingreso> Consultar()
        {
            return this.IConexion.Dias_Ingreso!.Take(5).ToList();
        }

        public Dias_Ingreso Insertar(Dias_Ingreso entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Dias_Ingreso!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Dias_Ingreso entidad)
        {
            return string.IsNullOrEmpty(entidad.Huella) ||
                string.IsNullOrEmpty(entidad.Tipo_Membresia) ||
                entidad.Id_Cliente <= 0 ||
                entidad.Hora_ingreso == default ||
                (entidad.Hora_salida.HasValue &&
                 entidad.Hora_salida <= entidad.Hora_ingreso);
        }
    }
}

