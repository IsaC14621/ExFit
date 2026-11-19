using lib_aplicaciones.entidades;
using presentaciones_AsistenciaTrabajadores.interfaces;
using presentaciones_gym.interfaces;

namespace lib_aplicaciones.implementaciones
{
    public class AsistenciaTrabajadoresPresentacion : IAsistenciaTrabajadoresPresentacion
    {
        private IComunicaciones IComunicaciones;

        public AsistenciaTrabajadoresPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public AsistenciaTrabajadores Actualizar(AsistenciaTrabajadores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<AsistenciaTrabajadores>(
                "AsistenciaTrabajadores/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public AsistenciaTrabajadores Borrar(AsistenciaTrabajadores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<AsistenciaTrabajadores>(
                "AsistenciaTrabajadores/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<AsistenciaTrabajadores> Buscar(AsistenciaTrabajadores entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<AsistenciaTrabajadores>>(
                "AsistenciaTrabajadores/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<AsistenciaTrabajadores> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<AsistenciaTrabajadores>>(
                "AsistenciaTrabajadores/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public AsistenciaTrabajadores Insertar(AsistenciaTrabajadores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<AsistenciaTrabajadores>(
                "AsistenciaTrabajadores/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(AsistenciaTrabajadores entidad)
        {
            return entidad.id_Trabajador <= 0 ||
                entidad.Fecha == default ||
                entidad.Hora_Entrada == default ||
                entidad.Hora_Salida == default;
        }
    }
}
