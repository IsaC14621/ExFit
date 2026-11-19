using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Rutinas_PersonalizadasController : ControllerBase
    {
        private IRutinas_PersonalizadasAplicacion IRutinas_PersonalizadasAplicacion;

        public Rutinas_PersonalizadasController(IRutinas_PersonalizadasAplicacion IRutinas_PersonalizadasAplicacion)
        {
            this.IRutinas_PersonalizadasAplicacion = IRutinas_PersonalizadasAplicacion;
        }

        [HttpPost]
        public List<Rutinas_Personalizadas> Consultar()
        {
            return this.IRutinas_PersonalizadasAplicacion.Consultar();
        }

        [HttpPost]
        public List<Rutinas_Personalizadas> Buscar(Rutinas_Personalizadas entidad)
        {
            return this.IRutinas_PersonalizadasAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Rutinas_Personalizadas Insertar(Rutinas_Personalizadas entidad)
        {
            return this.IRutinas_PersonalizadasAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Rutinas_Personalizadas Actualizar(Rutinas_Personalizadas entidad)
        {
            return this.IRutinas_PersonalizadasAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Rutinas_Personalizadas Borrar(Rutinas_Personalizadas entidad)
        {
            return this.IRutinas_PersonalizadasAplicacion.Borrar(entidad);
        }
    }
}
