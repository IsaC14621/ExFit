using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Dias_IngresoController : ControllerBase
    {
        private IDias_IngresoAplicacion IDias_IngresoAplicacion;

        public Dias_IngresoController(IDias_IngresoAplicacion IDias_IngresoAplicacion)
        {
            this.IDias_IngresoAplicacion = IDias_IngresoAplicacion;
        }

        [HttpPost]
        public List<Dias_Ingreso> Consultar()
        {
            return this.IDias_IngresoAplicacion.Consultar();
        }

        [HttpPost]
        public List<Dias_Ingreso> Buscar(Dias_Ingreso entidad)
        {
            return this.IDias_IngresoAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Dias_Ingreso Insertar(Dias_Ingreso entidad)
        {
            return this.IDias_IngresoAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Dias_Ingreso Actualizar(Dias_Ingreso entidad)
        {
            return this.IDias_IngresoAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Dias_Ingreso Borrar(Dias_Ingreso entidad)
        {
            return this.IDias_IngresoAplicacion.Borrar(entidad);
        }
    }
}