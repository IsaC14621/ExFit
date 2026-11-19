using lib_aplicaciones.entidades;

namespace lib_aplicaciones.interfaces
{
    public interface IAccesoAplicacion
    {
        Usuarios Ingresar(Credenciales entidad);
    }
}
