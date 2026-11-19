using lib_aplicaciones.entidades;
using presentaciones_Dias_Ingreso.interfaces;
using presentaciones_gym.interfaces;

namespace lib_aplicaciones.implementaciones
{
    public class Dias_IngresoPresentacion : IDias_IngresoPresentacion
    {
        private IComunicaciones IComunicaciones;

        public Dias_IngresoPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Dias_Ingreso Actualizar(Dias_Ingreso entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Dias_Ingreso>(
                "Dias_Ingreso/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Dias_Ingreso Borrar(Dias_Ingreso entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Dias_Ingreso>(
                "Dias_Ingreso/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Dias_Ingreso> Buscar(Dias_Ingreso entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Dias_Ingreso>>(
                "Dias_Ingreso/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Dias_Ingreso> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Dias_Ingreso>>(
                "Dias_Ingreso/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Dias_Ingreso Insertar(Dias_Ingreso entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Dias_Ingreso>(
                "Dias_Ingreso/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Dias_Ingreso entidad)
        {
            return string.IsNullOrEmpty(entidad.Huella) ||
                string.IsNullOrEmpty(entidad.Tipo_Membresia) ||
                entidad.Id_Cliente <= 0 ||
                entidad.Hora_ingreso == default ||
                (entidad.Hora_salida.HasValue &&
                 entidad.Hora_salida <= entidad.Hora_ingreso);
        }
    }
}