using lib_aplicaciones.entidades;

namespace presentaciones_Logins.interfaces
{
    public interface ILoginsPresentacion
    {
        Logins Insertar(Logins entidad);
        Logins Actualizar(Logins entidad);
        Logins Borrar(Logins entidad);
        List<Logins> Buscar(Logins entidad);
        List<Logins> Consultar();
    }
}