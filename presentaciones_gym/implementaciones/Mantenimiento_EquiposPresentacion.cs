using lib_aplicaciones.entidades;
using presentaciones_Mantenimiento_Equipos.interfaces;
using presentaciones_gym.interfaces;

namespace lib_aplicaciones.implementaciones
{
    public class Mantenimiento_EquiposPresentacion : IMantenimiento_EquiposPresentacion
    {
        private IComunicaciones IComunicaciones;

        public Mantenimiento_EquiposPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Mantenimiento_Equipos Actualizar(Mantenimiento_Equipos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Mantenimiento_Equipos>(
                "Mantenimiento_Equipos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Mantenimiento_Equipos Borrar(Mantenimiento_Equipos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Mantenimiento_Equipos>(
                "Mantenimiento_Equipos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Mantenimiento_Equipos> Buscar(Mantenimiento_Equipos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Mantenimiento_Equipos>>(
                "Mantenimiento_Equipos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Mantenimiento_Equipos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Mantenimiento_Equipos>>(
                "Mantenimiento_Equipos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Mantenimiento_Equipos Insertar(Mantenimiento_Equipos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Mantenimiento_Equipos>(
                "Mantenimiento_Equipos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Mantenimiento_Equipos entidad)
        {
            return string.IsNullOrEmpty(entidad.Nombre_equipo) ||
                entidad.Fecha_Mantenimiento == default ||
                entidad.Costo_Servicio <= 0 ||
                string.IsNullOrEmpty(entidad.Estado_Actual);
        }
    }
}
