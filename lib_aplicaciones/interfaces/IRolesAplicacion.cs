using lib_aplicaciones.entidades;

namespace lib_aplicaciones.interfaces
{
    public interface IRolesAplicacion
    {
        Roles Insertar(Roles entidad);
        Roles Actualizar(Roles entidad);
        Roles Borrar(Roles entidad);
        List<Roles> Buscar(Roles entidad);
        List<Roles> Consultar();
    }
}
