using lib_aplicaciones.entidades;
using presentaciones_Logins.interfaces;
using presentaciones_gym.interfaces;

namespace lib_aplicaciones.implementaciones
{
    public class LoginsPresentacion : ILoginsPresentacion
    {
        private IComunicaciones IComunicaciones;

        public LoginsPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Logins Actualizar(Logins entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Logins>(
                "Logins/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Logins Borrar(Logins entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Logins>(
                "Logins/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Logins> Buscar(Logins entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Logins>>(
                "Logins/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Logins> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Logins>>(
                "Logins/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Logins Insertar(Logins entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Logins>(
                "Logins/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Logins entidad)
        {
            return entidad.Usuario <= 0;
        }
    }
}
