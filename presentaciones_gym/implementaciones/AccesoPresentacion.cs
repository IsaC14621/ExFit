using lib_aplicaciones.entidades;
using presentaciones_Acceso.interfaces;
using presentaciones_gym.interfaces;

namespace lib_aplicaciones.implementaciones
{
    public class AccesoPresentacion : IAccesoPresentacion
    {
        private IComunicaciones IComunicaciones;

        public AccesoPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Usuarios Ingresar(Credenciales entidad)
        {
            if (string.IsNullOrEmpty(entidad.Correo) ||
                string.IsNullOrEmpty(entidad.Contrasena))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Usuarios>(
                "Acceso/Ingresar",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}