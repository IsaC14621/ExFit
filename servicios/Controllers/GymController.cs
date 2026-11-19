using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GymController : ControllerBase
    {
        private IGymAplicacion IGymAplicacion;

        public GymController(IGymAplicacion IGymAplicacion)
        {
            this.IGymAplicacion = IGymAplicacion;
        }

        [HttpPost]
        public List<Gym> Consultar()
        {
            return this.IGymAplicacion.Consultar();
        }

        [HttpPost]
        public List<Gym> Buscar(Gym entidad)
        {
            return this.IGymAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Gym Insertar(Gym entidad)
        {
            return this.IGymAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Gym Actualizar(Gym entidad)
        {
            return this.IGymAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Gym Borrar(Gym entidad)
        {
            return this.IGymAplicacion.Borrar(entidad);
        }
    }
}
