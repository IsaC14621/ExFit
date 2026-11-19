using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Mantenimiento_EquiposController : ControllerBase
    {
        private IMantenimiento_EquiposAplicacion IMantenimiento_EquiposAplicacion;

        public Mantenimiento_EquiposController(IMantenimiento_EquiposAplicacion IMantenimiento_EquiposAplicacion)
        {
            this.IMantenimiento_EquiposAplicacion = IMantenimiento_EquiposAplicacion;
        }

        [HttpPost]
        public List<Mantenimiento_Equipos> Consultar()
        {
            return this.IMantenimiento_EquiposAplicacion.Consultar();
        }

        [HttpPost]
        public List<Mantenimiento_Equipos> Buscar(Mantenimiento_Equipos entidad)
        {
            return this.IMantenimiento_EquiposAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Mantenimiento_Equipos Insertar(Mantenimiento_Equipos entidad)
        {
            return this.IMantenimiento_EquiposAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Mantenimiento_Equipos Actualizar(Mantenimiento_Equipos entidad)
        {
            return this.IMantenimiento_EquiposAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Mantenimiento_Equipos Borrar(Mantenimiento_Equipos entidad)
        {
            return this.IMantenimiento_EquiposAplicacion.Borrar(entidad);
        }
    }
}