using lib_aplicaciones.entidades;

namespace lib_aplicaciones.interfaces
{
    public interface ILoginsAplicacion
    {
        Logins Insertar(Logins entidad);
        Logins Actualizar(Logins entidad);
        Logins Borrar(Logins entidad);
        List<Logins> Buscar(Logins entidad);
        List<Logins> Consultar();
    }
}
