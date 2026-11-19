using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AsistenciaTrabajadoresController : ControllerBase
    {
        private IAsistenciaTrabajadoresAplicacion IAsistenciaTrabajadoresAplicacion;

        public AsistenciaTrabajadoresController(IAsistenciaTrabajadoresAplicacion IAsistenciaTrabajadoresAplicacion)
        {
            this.IAsistenciaTrabajadoresAplicacion = IAsistenciaTrabajadoresAplicacion;
        }

        [HttpPost]
        public List<AsistenciaTrabajadores> Consultar()
        {
            return this.IAsistenciaTrabajadoresAplicacion.Consultar();
        }

        [HttpPost]
        public List<AsistenciaTrabajadores> Buscar(AsistenciaTrabajadores entidad)
        {
            return this.IAsistenciaTrabajadoresAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public AsistenciaTrabajadores Insertar(AsistenciaTrabajadores entidad)
        {
            return this.IAsistenciaTrabajadoresAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public AsistenciaTrabajadores Actualizar(AsistenciaTrabajadores entidad)
        {
            return this.IAsistenciaTrabajadoresAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public AsistenciaTrabajadores Borrar(AsistenciaTrabajadores entidad)
        {
            return this.IAsistenciaTrabajadoresAplicacion.Borrar(entidad);
        }
    }
}
