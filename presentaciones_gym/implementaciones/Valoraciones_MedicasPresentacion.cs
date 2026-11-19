using lib_aplicaciones.entidades;
using presentaciones_Valoraciones_Medicas.interfaces;
using presentaciones_gym.interfaces;

namespace lib_aplicaciones.implementaciones
{
    public class Valoraciones_MedicasPresentacion : IValoraciones_MedicasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public Valoraciones_MedicasPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Valoraciones_Medicas Actualizar(Valoraciones_Medicas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Valoraciones_Medicas>(
                "Valoraciones_Medicas/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Valoraciones_Medicas Borrar(Valoraciones_Medicas entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Valoraciones_Medicas>(
                "Valoraciones_Medicas/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Valoraciones_Medicas> Buscar(Valoraciones_Medicas entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Valoraciones_Medicas>>(
                "Valoraciones_Medicas/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Valoraciones_Medicas> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Valoraciones_Medicas>>(
                "Valoraciones_Medicas/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Valoraciones_Medicas Insertar(Valoraciones_Medicas entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Valoraciones_Medicas>(
                "Valoraciones_Medicas/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Valoraciones_Medicas entidad)
        {
            return entidad.Id_Cliente <= 0 ||
                entidad.Peso <= 0 ||
                entidad.Estatura <= 0 ||
                entidad.Fecha_Evaluacion == default;
        }
    }
}
