using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CasillerosController : ControllerBase
    {
        private ICasillerosAplicacion ICasillerosAplicacion;

        public CasillerosController(ICasillerosAplicacion ICasillerosAplicacion)
        {
            this.ICasillerosAplicacion = ICasillerosAplicacion;
        }

        [HttpPost]
        public List<Casilleros> Consultar()
        {
            return this.ICasillerosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Casilleros> Buscar(Casilleros entidad)
        {
            return this.ICasillerosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Casilleros Insertar(Casilleros entidad)
        {
            return this.ICasillerosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Casilleros Actualizar(Casilleros entidad)
        {
            return this.ICasillerosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Casilleros Borrar(Casilleros entidad)
        {
            return this.ICasillerosAplicacion.Borrar(entidad);
        }
    }
}
