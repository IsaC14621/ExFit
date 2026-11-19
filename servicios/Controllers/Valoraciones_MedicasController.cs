using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Valoraciones_MedicasController : ControllerBase
    {
        private IValoraciones_MedicasAplicacion IValoraciones_MedicasAplicacion;

        public Valoraciones_MedicasController(IValoraciones_MedicasAplicacion IValoraciones_MedicasAplicacion)
        {
            this.IValoraciones_MedicasAplicacion = IValoraciones_MedicasAplicacion;
        }

        [HttpPost]
        public List<Valoraciones_Medicas> Consultar()
        {
            return this.IValoraciones_MedicasAplicacion.Consultar();
        }

        [HttpPost]
        public List<Valoraciones_Medicas> Buscar(Valoraciones_Medicas entidad)
        {
            return this.IValoraciones_MedicasAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Valoraciones_Medicas Insertar(Valoraciones_Medicas entidad)
        {
            return this.IValoraciones_MedicasAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Valoraciones_Medicas Actualizar(Valoraciones_Medicas entidad)
        {
            return this.IValoraciones_MedicasAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Valoraciones_Medicas Borrar(Valoraciones_Medicas entidad)
        {
            return this.IValoraciones_MedicasAplicacion.Borrar(entidad);
        }
    }
}
