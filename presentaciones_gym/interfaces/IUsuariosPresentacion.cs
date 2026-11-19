using lib_aplicaciones.entidades;

namespace presentaciones_Usuarios.interfaces
{
    public interface IUsuariosPresentacion
    {
        Usuarios Insertar(Usuarios entidad);
        Usuarios Actualizar(Usuarios entidad);
        Usuarios Borrar(Usuarios entidad);
        List<Usuarios> Buscar(Usuarios entidad);
        List<Usuarios> Consultar();
    }
}
