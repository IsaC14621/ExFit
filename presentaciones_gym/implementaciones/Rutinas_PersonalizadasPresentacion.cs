using lib_aplicaciones.entidades;
using presentaciones_Rutinas_Personalizadas.interfaces;
using presentaciones_gym.interfaces;

namespace lib_aplicaciones.implementaciones
{
    public class Rutinas_PersonalizadasPresentacion : IRutinas_PersonalizadasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public Rutinas_PersonalizadasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Rutinas_Personalizadas Actualizar(Rutinas_Personalizadas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Rutinas_Personalizadas>(
                "Rutinas_Personalizadas/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Rutinas_Personalizadas Borrar(Rutinas_Personalizadas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Rutinas_Personalizadas>(
                "Rutinas_Personalizadas/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Rutinas_Personalizadas> Buscar(Rutinas_Personalizadas entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Rutinas_Personalizadas>>(
                "Rutinas_Personalizadas/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Rutinas_Personalizadas> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Rutinas_Personalizadas>>(
                "Rutinas_Personalizadas/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Rutinas_Personalizadas Insertar(Rutinas_Personalizadas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Rutinas_Personalizadas>(
                "Rutinas_Personalizadas/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Rutinas_Personalizadas entidad)
        {
            return entidad.id_Cliente <= 0 ||
                string.IsNullOrEmpty(entidad.Nombre_Rutina) ||
                entidad.Fecha_Inicio == default;
        }
    }
}
