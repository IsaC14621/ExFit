using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ClasesController : ControllerBase
    {
        private IClasesAplicacion IClasesAplicacion;

        public ClasesController(IClasesAplicacion IClasesAplicacion)
        {
            this.IClasesAplicacion = IClasesAplicacion;
        }

        [HttpPost]
        public List<Clases> Consultar()
        {
            return this.IClasesAplicacion.Consultar();
        }

        [HttpPost]
        public List<Clases> Buscar(Clases entidad)
        {
            return this.IClasesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Clases Insertar(Clases entidad)
        {
            return this.IClasesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Clases Actualizar(Clases entidad)
        {
            return this.IClasesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Clases Borrar(Clases entidad)
        {
            return this.IClasesAplicacion.Borrar(entidad);
        }
    }
}
