using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class LoginsController : ControllerBase
    {
        private ILoginsAplicacion ILoginsAplicacion;

        public LoginsController(ILoginsAplicacion ILoginsAplicacion)
        {
            this.ILoginsAplicacion = ILoginsAplicacion;
        }

        [HttpPost]
        public List<Logins> Consultar()
        {
            return this.ILoginsAplicacion.Consultar();
        }

        [HttpPost]
        public List<Logins> Buscar(Logins entidad)
        {
            return this.ILoginsAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Logins Insertar(Logins entidad)
        {
            return this.ILoginsAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Logins Actualizar(Logins entidad)
        {
            return this.ILoginsAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Logins Borrar(Logins entidad)
        {
            return this.ILoginsAplicacion.Borrar(entidad);
        }
    }
}
