using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_aplicaciones.implementaciones
{
    public class Reservas_ClasesAplicacion : IReservas_ClasesAplicacion
    {
        private IConexion IConexion;

        public Reservas_ClasesAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Reservas_Clases Actualizar(Reservas_Clases entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Reservas_Clases>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Reservas_Clases Borrar(Reservas_Clases entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Reservas_Clases!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Reservas_Clases> Buscar(Reservas_Clases entidad)
        {
            return this.IConexion.Reservas_Clases!
                .Where(x => entidad.id_Cliente == 0 ||
                            x.id_Cliente == entidad.id_Cliente)
                .ToList();
        }

        public List<Reservas_Clases> Consultar()
        {
            return this.IConexion.Reservas_Clases!.Take(5).ToList();
        }

        public Reservas_Clases Insertar(Reservas_Clases entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Reservas_Clases!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Reservas_Clases entidad)
        {
            return entidad.id_Clase <= 0 ||
                !this.IConexion.Clases!.Any(x => x.Id == entidad.id_Clase) ||
                entidad.id_Cliente <= 0 ||
                !this.IConexion.Clientes!.Any(x => x.Id == entidad.id_Cliente) ||
                string.IsNullOrEmpty(entidad.Tipo_Membresia) ||
                entidad.Fecha_Reserva == default;
        }
    }
}

