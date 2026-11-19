using lib_aplicaciones.entidades;
using presentaciones_Membresias.interfaces;
using presentaciones_gym.interfaces;

namespace lib_aplicaciones.implementaciones
{
    public class MembresiasPresentacion : IMembresiasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public MembresiasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Membresias Actualizar(Membresias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Membresias>(
                "Membresias/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Membresias Borrar(Membresias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Membresias>(
                "Membresias/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Membresias> Buscar(Membresias entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Membresias>>(
                "Membresias/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Membresias> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Membresias>>(
                "Membresias/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Membresias Insertar(Membresias entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Membresias>(
                "Membresias/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Membresias entidad)
        {
            return entidad.Cliente <= 0;
        }
    }
}