using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Detalle_ProductoController : ControllerBase
    {
        private IDetalle_ProductoAplicacion IDetalle_ProductoAplicacion;

        public Detalle_ProductoController(IDetalle_ProductoAplicacion IDetalle_ProductoAplicacion)
        {
            this.IDetalle_ProductoAplicacion = IDetalle_ProductoAplicacion;
        }

        [HttpPost]
        public List<Detalle_Producto> Consultar()
        {
            return this.IDetalle_ProductoAplicacion.Consultar();
        }

        [HttpPost]
        public List<Detalle_Producto> Buscar(Detalle_Producto entidad)
        {
            return this.IDetalle_ProductoAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Detalle_Producto Insertar(Detalle_Producto entidad)
        {
            return this.IDetalle_ProductoAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Detalle_Producto Actualizar(Detalle_Producto entidad)
        {
            return this.IDetalle_ProductoAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Detalle_Producto Borrar(Detalle_Producto entidad)
        {
            return this.IDetalle_ProductoAplicacion.Borrar(entidad);
        }
    }
}