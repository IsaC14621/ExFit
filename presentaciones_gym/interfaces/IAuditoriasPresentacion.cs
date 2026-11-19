using lib_aplicaciones.entidades;

namespace presentaciones_Auditorias.interfaces
{
    public interface IAuditoriasPresentacion
    {
        Auditorias Insertar(Auditorias entidad);
        Auditorias Actualizar(Auditorias entidad);
        Auditorias Borrar(Auditorias entidad);
        List<Auditorias> Buscar(Auditorias entidad);
        List<Auditorias> Consultar();
    }
}
