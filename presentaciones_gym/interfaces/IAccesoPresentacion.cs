using lib_aplicaciones.entidades;

namespace presentaciones_Acceso.interfaces
{
    public interface IAccesoPresentacion
    {
        Usuarios Ingresar(Credenciales entidad);
    }
}