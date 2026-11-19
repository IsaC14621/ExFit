using lib_aplicaciones.entidades;
using presentaciones_Tipo_Clases.interfaces;
using presentaciones_gym.interfaces;

namespace lib_aplicaciones.implementaciones
{
    public class Tipo_ClasesPresentacion : ITipo_ClasesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public Tipo_ClasesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Tipo_Clases Actualizar(Tipo_Clases entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Tipo_Clases>(
                "Tipo_Clases/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Tipo_Clases Borrar(Tipo_Clases entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Tipo_Clases>(
                "Tipo_Clases/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Tipo_Clases> Buscar(Tipo_Clases entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Tipo_Clases>>(
                "Tipo_Clases/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Tipo_Clases> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Tipo_Clases>>(
                "Tipo_Clases/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Tipo_Clases Insertar(Tipo_Clases entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Tipo_Clases>(
                "Tipo_Clases/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Tipo_Clases entidad)
        {
            return false;        // Los cuatro campos son bool y opcionales en la base de datos.
        }
    }
}

