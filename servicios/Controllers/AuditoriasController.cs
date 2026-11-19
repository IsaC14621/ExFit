using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace servicios.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuditoriasController : ControllerBase
    {
        private IAuditoriasAplicacion IAuditoriasAplicacion;

        public AuditoriasController(IAuditoriasAplicacion IAuditoriasAplicacion)
        {
            this.IAuditoriasAplicacion = IAuditoriasAplicacion;
        }

        [HttpPost]
        public List<Auditorias> Consultar()
        {
            return this.IAuditoriasAplicacion.Consultar();
        }

        [HttpPost]
        public List<Auditorias> Buscar(Auditorias entidad)
        {
            return this.IAuditoriasAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Auditorias Insertar(Auditorias entidad)
        {
            return this.IAuditoriasAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Auditorias Actualizar(Auditorias entidad)
        {
            return this.IAuditoriasAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Auditorias Borrar(Auditorias entidad)
        {
            return this.IAuditoriasAplicacion.Borrar(entidad);
        }
    }
}