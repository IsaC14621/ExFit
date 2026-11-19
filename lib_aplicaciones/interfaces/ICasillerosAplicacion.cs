using lib_aplicaciones.entidades;

namespace lib_aplicaciones.interfaces
{
    public interface ICasillerosAplicacion
    {
        Casilleros Insertar(Casilleros entidad);
        Casilleros Actualizar(Casilleros entidad);
        Casilleros Borrar(Casilleros entidad);
        List<Casilleros> Buscar(Casilleros entidad);
        List<Casilleros> Consultar();
    }
}