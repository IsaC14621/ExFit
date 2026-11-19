using lib_aplicaciones.entidades;
using presentaciones_Trabajadores.interfaces;
using presentaciones_gym.interfaces;

namespace lib_aplicaciones.implementaciones
{
    public class TrabajadoresPresentacion : ITrabajadoresPresentacion
    {
        private IComunicaciones IComunicaciones;

        public TrabajadoresPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Trabajadores Actualizar(Trabajadores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Trabajadores>(
                "Trabajadores/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Trabajadores Borrar(Trabajadores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Trabajadores>(
                "Trabajadores/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Trabajadores> Buscar(Trabajadores entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Trabajadores>>(
                "Trabajadores/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Trabajadores> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Trabajadores>>(
                "Trabajadores/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Trabajadores Insertar(Trabajadores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Trabajadores>(
                "Trabajadores/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Trabajadores entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre) ||
                string.IsNullOrEmpty(entidad.C_c) ||
                string.IsNullOrEmpty(entidad.Cargo) ||
                 entidad.Salario <= 0 ||
                entidad.Edad <= 0;
        }
    }
}
