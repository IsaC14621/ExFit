using lib_aplicaciones.entidades;
using presentaciones_Reservas_Clases.interfaces;
using presentaciones_gym.interfaces;

namespace lib_aplicaciones.implementaciones
{
    public class Reservas_ClasesPresentacion : IReservas_ClasesPresentacion
    {
        private IComunicaciones IComunicaciones;

        public Reservas_ClasesPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Reservas_Clases Actualizar(Reservas_Clases entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Reservas_Clases>(
                "Reservas_Clases/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Reservas_Clases Borrar(Reservas_Clases entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Reservas_Clases>(
                "Reservas_Clases/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Reservas_Clases> Buscar(Reservas_Clases entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Reservas_Clases>>(
                "Reservas_Clases/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Reservas_Clases> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Reservas_Clases>>(
                "Reservas_Clases/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Reservas_Clases Insertar(Reservas_Clases entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Reservas_Clases>(
                "Reservas_Clases/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Reservas_Clases entidad)
        {
            return entidad.id_Clase <= 0 ||
                entidad.id_Cliente <= 0 ||
                string.IsNullOrEmpty(entidad.Tipo_Membresia) ||
                entidad.Fecha_Reserva == default;
        }
    }
}
