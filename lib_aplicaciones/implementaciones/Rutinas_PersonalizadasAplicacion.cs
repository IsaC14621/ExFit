using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.implementaciones
{
    public class Rutinas_PersonalizadasAplicacion : IRutinas_PersonalizadasAplicacion
    {
        private IConexion IConexion;

        public Rutinas_PersonalizadasAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Rutinas_Personalizadas Actualizar(Rutinas_Personalizadas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Rutinas_Personalizadas>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Rutinas_Personalizadas Borrar(Rutinas_Personalizadas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Rutinas_Personalizadas!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Rutinas_Personalizadas> Buscar(Rutinas_Personalizadas entidad)
        {
            return this.IConexion.Rutinas_Personalizadas!
                .Where(x => entidad.id_Cliente == 0 ||
                            x.id_Cliente == entidad.id_Cliente)
                .ToList();
        }

        public List<Rutinas_Personalizadas> Consultar()
        {
            return this.IConexion.Rutinas_Personalizadas!.Take(5).ToList();
        }

        public Rutinas_Personalizadas Insertar(Rutinas_Personalizadas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Rutinas_Personalizadas!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Rutinas_Personalizadas entidad)
        {
            return entidad.id_Cliente <= 0 ||
                !this.IConexion.Clientes!.Any(x => x.Id == entidad.id_Cliente) ||
                string.IsNullOrEmpty(entidad.Nombre_Rutina) ||
                entidad.Fecha_Inicio == default;
        }
    }
}

