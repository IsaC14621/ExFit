using lib_aplicaciones.entidades;
using presentaciones_Detalle_Producto.interfaces;
using presentaciones_gym.interfaces;

namespace lib_aplicaciones.implementaciones
{
    public class Detalle_ProductoPresentacion : IDetalle_ProductoPresentacion
    {
        private IComunicaciones IComunicaciones;

        public Detalle_ProductoPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Detalle_Producto Actualizar(Detalle_Producto entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Detalle_Producto>(
                "Detalle_Producto/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Detalle_Producto Borrar(Detalle_Producto entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Detalle_Producto>(
                "Detalle_Producto/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Detalle_Producto> Buscar(Detalle_Producto entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Detalle_Producto>>(
                "Detalle_Producto/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Detalle_Producto> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Detalle_Producto>>(
                "Detalle_Producto/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Detalle_Producto Insertar(Detalle_Producto entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Detalle_Producto>(
                "Detalle_Producto/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Detalle_Producto entidad)
        {
            return entidad.id_Venta <= 0 ||
                entidad.Id_Producto <= 0 ||
                entidad.Cantidad <= 0 ||
                entidad.Subtotal <= 0;
        }
    }
}