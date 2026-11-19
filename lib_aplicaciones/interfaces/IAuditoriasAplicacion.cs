using lib_aplicaciones.entidades;

namespace lib_aplicaciones.interfaces
{
    public interface IAuditoriasAplicacion
    {
        Auditorias Insertar(Auditorias entidad);
        Auditorias Actualizar(Auditorias entidad);
        Auditorias Borrar(Auditorias entidad);
        List<Auditorias> Buscar(Auditorias entidad);
        List<Auditorias> Consultar();
    }
}