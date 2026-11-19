using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Reservas_ClasesController : ControllerBase
    {
        private IReservas_ClasesAplicacion IReservas_ClasesAplicacion;

        public Reservas_ClasesController(IReservas_ClasesAplicacion IReservas_ClasesAplicacion)
        {
            this.IReservas_ClasesAplicacion = IReservas_ClasesAplicacion;
        }

        [HttpPost]
        public List<Reservas_Clases> Consultar()
        {
            return this.IReservas_ClasesAplicacion.Consultar();
        }

        [HttpPost]
        public List<Reservas_Clases> Buscar(Reservas_Clases entidad)
        {
            return this.IReservas_ClasesAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Reservas_Clases Insertar(Reservas_Clases entidad)
        {
            return this.IReservas_ClasesAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Reservas_Clases Actualizar(Reservas_Clases entidad)
        {
            return this.IReservas_ClasesAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Reservas_Clases Borrar(Reservas_Clases entidad)
        {
            return this.IReservas_ClasesAplicacion.Borrar(entidad);
        }
    }
}