using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MembresiasController : ControllerBase
    {
        private IMembresiasAplicacion IMembresiasAplicacion;

        public MembresiasController(IMembresiasAplicacion IMembresiasAplicacion)
        {
            this.IMembresiasAplicacion = IMembresiasAplicacion;
        }

        [HttpPost]
        public List<Membresias> Consultar()
        {
            return this.IMembresiasAplicacion.Consultar();
        }

        [HttpPost]
        public List<Membresias> Buscar(Membresias entidad)
        {
            return this.IMembresiasAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Membresias Insertar(Membresias entidad)
        {
            return this.IMembresiasAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Membresias Actualizar(Membresias entidad)
        {
            return this.IMembresiasAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Membresias Borrar(Membresias entidad)
        {
            return this.IMembresiasAplicacion.Borrar(entidad);
        }
    }
}