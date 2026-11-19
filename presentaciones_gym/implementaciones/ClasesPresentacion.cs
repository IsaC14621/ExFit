using lib_aplicaciones.entidades;
using presentaciones_Clases.interfaces;
using presentaciones_gym.interfaces;

namespace lib_aplicaciones.implementaciones
{
    public class ClasesPresentacion : IClasesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public ClasesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Clases Actualizar(Clases entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Clases>(
                "Clases/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Clases Borrar(Clases entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Clases>(
                "Clases/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Clases> Buscar(Clases entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Clases>>(
                "Clases/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Clases> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Clases>>(
                "Clases/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Clases Insertar(Clases entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Clases>(
                "Clases/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Clases entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre_Clase) ||
                entidad.Tipo_Clase <= 0 ||
                entidad.Fecha == default ||
                entidad.Horario == default;
        }
    }
}