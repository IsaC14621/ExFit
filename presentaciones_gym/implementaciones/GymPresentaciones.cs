using lib_aplicaciones.entidades;
using presentaciones_Gym.interfaces;
using presentaciones_gym.interfaces;

namespace lib_aplicaciones.implementaciones
{
    public class GymPresentacion : IGymPresentacion
    {
        private IComunicaciones IComunicaciones;

        public GymPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Gym Actualizar(Gym entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Gym>(
                "Gym/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Gym Borrar(Gym entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Gym>(
                "Gym/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Gym> Buscar(Gym entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Gym>>(
                "Gym/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Gym> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Gym>>(
                "Gym/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Gym Insertar(Gym entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Gym>(
                "Gym/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }


        private bool Validar(Gym entidad)
        {
            return string.IsNullOrEmpty(entidad.direccion) ||
                string.IsNullOrEmpty(entidad.horario);
        }
    }
}
