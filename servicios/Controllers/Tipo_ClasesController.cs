using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Tipo_ClasesController : ControllerBase
    {
        private ITipo_ClasesAplicacion ITipo_ClasesAplicacion;

        public Tipo_ClasesController(ITipo_ClasesAplicacion ITipo_ClasesAplicacion)
        {
            this.ITipo_ClasesAplicacion = ITipo_ClasesAplicacion;
        }

        [HttpPost]
        public List<Tipo_Clases> Consultar()
        {
            return this.ITipo_ClasesAplicacion.Consultar();
        }

        [HttpPost]
        public List<Tipo_Clases> Buscar(Tipo_Clases entidad)
        {
            return this.ITipo_ClasesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Tipo_Clases Insertar(Tipo_Clases entidad)
        {
            return this.ITipo_ClasesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Tipo_Clases Actualizar(Tipo_Clases entidad)
        {
            return this.ITipo_ClasesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Tipo_Clases Borrar(Tipo_Clases entidad)
        {
            return this.ITipo_ClasesAplicacion.Borrar(entidad);
        }
    }
}
