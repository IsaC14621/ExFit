using lib_aplicaciones.entidades;
using presentaciones_Ejercicios.interfaces;
using presentaciones_gym.interfaces;

namespace lib_aplicaciones.implementaciones
{
    public class EjerciciosPresentacion : IEjerciciosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public EjerciciosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Ejercicios Actualizar(Ejercicios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Ejercicios>(
                "Ejercicios/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Ejercicios Borrar(Ejercicios entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Ejercicios>(
                "Ejercicios/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Ejercicios> Buscar(Ejercicios entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Ejercicios>>(
                "Ejercicios/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Ejercicios> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Ejercicios>>(
                "Ejercicios/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Ejercicios Insertar(Ejercicios entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Ejercicios>(
                "Ejercicios/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Ejercicios entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre_Ejercicio) ||
                string.IsNullOrEmpty(entidad.Grupo_Muscular);
        }
    }
}
