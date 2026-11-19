using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CargosController : ControllerBase
    {
        private ICargosAplicacion ICargosAplicacion;

        public CargosController(ICargosAplicacion ICargosAplicacion)
        {
            this.ICargosAplicacion = ICargosAplicacion;
        }

        [HttpPost]
        public List<Cargos> Consultar()
        {
            return this.ICargosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Cargos> Buscar(Cargos entidad)
        {
            return this.ICargosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Cargos Insertar(Cargos entidad)
        {
            return this.ICargosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Cargos Actualizar(Cargos entidad)
        {
            return this.ICargosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Cargos Borrar(Cargos entidad)
        {
            return this.ICargosAplicacion.Borrar(entidad);
        }
    }
}