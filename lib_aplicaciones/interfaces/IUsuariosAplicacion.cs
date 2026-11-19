using lib_aplicaciones.entidades;

namespace lib_aplicaciones.interfaces
{
    public interface IUsuariosAplicacion
    {
        Usuarios Insertar(Usuarios entidad);
        Usuarios Actualizar(Usuarios entidad);
        Usuarios Borrar(Usuarios entidad);
        List<Usuarios> Buscar(Usuarios entidad);
        List<Usuarios> Consultar();
    }
}

