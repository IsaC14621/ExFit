using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.implementaciones
{
    public class Valoraciones_MedicasAplicacion : IValoraciones_MedicasAplicacion
    {
        private IConexion IConexion;

        public Valoraciones_MedicasAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Valoraciones_Medicas Actualizar(Valoraciones_Medicas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Valoraciones_Medicas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Valoraciones_Medicas Borrar(Valoraciones_Medicas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Valoraciones_Medicas!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Valoraciones_Medicas> Buscar(Valoraciones_Medicas entidad)
        {
            return this.IConexion.Valoraciones_Medicas!
                .Where(x => entidad.Id_Cliente == 0 ||
                            x.Id_Cliente == entidad.Id_Cliente)
                .ToList();
        }

        public List<Valoraciones_Medicas> Consultar()
        {
            return this.IConexion.Valoraciones_Medicas!.Take(5).ToList();
        }

        public Valoraciones_Medicas Insertar(Valoraciones_Medicas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Valoraciones_Medicas!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Valoraciones_Medicas entidad)
        {
            return entidad.Id_Cliente <= 0 ||
                !this.IConexion.Clientes!.Any(x => x.Id == entidad.Id_Cliente) ||
                entidad.Peso <= 0 ||
                entidad.Estatura <= 0 ||
                entidad.Fecha_Evaluacion == default;
        }
    }
}
