using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TiendaController : ControllerBase
    {
        private ITiendaAplicacion ITiendaAplicacion;

        public TiendaController(ITiendaAplicacion ITiendaAplicacion)
        {
            this.ITiendaAplicacion = ITiendaAplicacion;
        }

        [HttpPost]
        public List<Tienda> Consultar()
        {
            return this.ITiendaAplicacion.Consultar();
        }

        [HttpPost]
        public List<Tienda> Buscar(Tienda entidad)
        {
            return this.ITiendaAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Tienda Insertar(Tienda entidad)
        {
            return this.ITiendaAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Tienda Actualizar(Tienda entidad)
        {
            return this.ITiendaAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Tienda Borrar(Tienda entidad)
        {
            return this.ITiendaAplicacion.Borrar(entidad);
        }
    }
}