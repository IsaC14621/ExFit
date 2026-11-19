using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_aplicaciones.implementaciones
{
    public class GymAplicacion : IGymAplicacion
    {
        private IConexion IConexion;

        public GymAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Gym Actualizar(Gym entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Gym>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Gym Borrar(Gym entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Gym!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Gym> Buscar(Gym entidad)
        {
            return this.IConexion.Gym!
                .Where(x => x.direccion!.Contains(entidad.direccion!))
                .ToList();
        }

        public List<Gym> Consultar()
        {
            return this.IConexion.Gym!.Take(5).ToList();
        }

        public Gym Insertar(Gym entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Gym!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Gym entidad)
        {
            return string.IsNullOrEmpty(entidad.direccion) ||
                string.IsNullOrEmpty(entidad.horario);
        }
    }
}

