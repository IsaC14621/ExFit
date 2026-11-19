using lib_aplicaciones.entidades;
using presentaciones_Tienda.interfaces;
using presentaciones_gym.interfaces;

namespace lib_aplicaciones.implementaciones
{
    public class TiendaPresentacion : ITiendaPresentacion
    {
        private IComunicaciones IComunicaciones;

        public TiendaPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Tienda Actualizar(Tienda entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Tienda>(
                "Tienda/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Tienda Borrar(Tienda entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Tienda>(
                "Tienda/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Tienda> Buscar(Tienda entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Tienda>>(
                "Tienda/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Tienda> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Tienda>>(
                "Tienda/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Tienda Insertar(Tienda entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Tienda>(
                "Tienda/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Tienda entidad)
        {
            return entidad.id_Producto <= 0 ||
                entidad.Precio <= 0 ||
                entidad.Cantidad_Disponible < 0 ||
                entidad.Cantidad_Productos < 0 ||
                entidad.Id_Provedor <= 0;
        }
    }
}