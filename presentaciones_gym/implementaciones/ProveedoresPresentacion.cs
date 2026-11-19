using lib_aplicaciones.entidades;
using presentaciones_Proveedores.interfaces;
using presentaciones_gym.interfaces;

namespace lib_aplicaciones.implementaciones
{
    public class ProveedoresPresentacion : IProveedoresPresentacion
    {
        private IComunicaciones IComunicaciones;

        public ProveedoresPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Proveedores Actualizar(Proveedores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Proveedores>(
                "Proveedores/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Proveedores Borrar(Proveedores entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Proveedores>(
                "Proveedores/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Proveedores> Buscar(Proveedores entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Proveedores>>(
                "Proveedores/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Proveedores> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Proveedores>>(
                "Proveedores/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Proveedores Insertar(Proveedores entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Proveedores>(
                "Proveedores/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Proveedores entidad)
        {
            return entidad.Id_Tienda <= 0 ||
                string.IsNullOrEmpty(entidad.Nombre_Empresa) ||
                string.IsNullOrEmpty(entidad.Tipo_Producto);
        }
    }
}