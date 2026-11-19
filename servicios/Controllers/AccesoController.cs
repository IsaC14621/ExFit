using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccesoController : ControllerBase
    {
        private IAccesoAplicacion IAccesoAplicacion;

        public AccesoController(IAccesoAplicacion IAccesoAplicacion)
        {
            this.IAccesoAplicacion = IAccesoAplicacion;
        }

        [HttpPost]
        public Usuarios Ingresar(Credenciales entidad)
        {
            return this.IAccesoAplicacion.Ingresar(entidad);
        }
    }
}