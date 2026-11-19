using lib_aplicaciones.entidades;
using presentaciones_Casilleros.interfaces;
using presentaciones_gym.interfaces;

namespace lib_aplicaciones.implementaciones
{
    public class CasillerosPresentacion : ICasillerosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public CasillerosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Casilleros Actualizar(Casilleros entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Casilleros>(
                "Casilleros/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Casilleros Borrar(Casilleros entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Casilleros>(
                "Casilleros/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Casilleros> Buscar(Casilleros entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Casilleros>>(
                "Casilleros/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Casilleros> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Casilleros>>(
                "Casilleros/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Casilleros Insertar(Casilleros entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Casilleros>(
                "Casilleros/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Casilleros entidad)
        {
            return entidad.Numero_Casillero <= 0 ||
                entidad.id_Cliente <= 0 ||
                string.IsNullOrEmpty(entidad.Estado);
        }
    }
}