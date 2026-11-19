using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class EjerciciosController : ControllerBase
    {
        private IEjerciciosAplicacion IEjerciciosAplicacion;

        public EjerciciosController(IEjerciciosAplicacion IEjerciciosAplicacion)
        {
            this.IEjerciciosAplicacion = IEjerciciosAplicacion;
        }

        [HttpPost]
        public List<Ejercicios> Consultar()
        {
            return this.IEjerciciosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Ejercicios> Buscar(Ejercicios entidad)
        {
            return this.IEjerciciosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Ejercicios Insertar(Ejercicios entidad)
        {
            return this.IEjerciciosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Ejercicios Actualizar(Ejercicios entidad)
        {
            return this.IEjerciciosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Ejercicios Borrar(Ejercicios entidad)
        {
            return this.IEjerciciosAplicacion.Borrar(entidad);
        }
    }
}
