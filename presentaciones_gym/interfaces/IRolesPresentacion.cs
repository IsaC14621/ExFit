using lib_aplicaciones.entidades;

namespace presentaciones_Roles.interfaces
{
    public interface IRolesPresentacion
    {
        Roles Insertar(Roles entidad);
        Roles Actualizar(Roles entidad);
        Roles Borrar(Roles entidad);
        List<Roles> Buscar(Roles entidad);
        List<Roles> Consultar();
    }
}
