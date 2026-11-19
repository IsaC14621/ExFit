using lib_aplicaciones.entidades;
using presentaciones_Productos.interfaces;
using presentaciones_gym.interfaces;

namespace lib_aplicaciones.implementaciones
{
    public class ProductosPresentacion : IProductosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public ProductosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Productos Actualizar(Productos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Productos>(
                "Productos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Productos Borrar(Productos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Productos>(
                "Productos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Productos> Buscar(Productos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Productos>>(
                "Productos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Productos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Productos>>(
                "Productos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Productos Insertar(Productos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Productos>(
                "Productos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Productos entidad)
        {
            return entidad.Id_Cliente <= 0 ||
                entidad.Id_Vendedor <= 0 ||
                string.IsNullOrEmpty(entidad.Nombre_Producto) ||
                entidad.Fecha_Venta == default ||
                entidad.Total <= 0;
        }
    }
}
