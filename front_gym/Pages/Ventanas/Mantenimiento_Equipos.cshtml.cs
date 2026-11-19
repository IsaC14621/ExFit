using lib_aplicaciones.entidades;
using lib_aplicaciones.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentaciones_Mantenimiento_Equipos.interfaces;

namespace front_gym.Pages.Ventanas
{
    public class Mantenimiento_EquiposModel : PageModel
    {
        private IMantenimiento_EquiposPresentacion IMantenimiento_EquiposPresentacion;

        public Mantenimiento_EquiposModel(IMantenimiento_EquiposPresentacion IMantenimiento_EquiposPresentacion)
        {
            this.IMantenimiento_EquiposPresentacion = IMantenimiento_EquiposPresentacion;
            this.Filtro = new Mantenimiento_Equipos();
        }

        [BindProperty] public List<Mantenimiento_Equipos> Lista { get; set; }
        [BindProperty] public Mantenimiento_Equipos? Filtro { get; set; }
        [BindProperty] public Mantenimiento_Equipos? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                Filtro!.Nombre_equipo = Filtro!.Nombre_equipo ?? "";
                Lista = this.IMantenimiento_EquiposPresentacion.Buscar(Filtro!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtNuevo()
        {
            try
            {
                Formulario = true;
                this.Actual = new Mantenimiento_Equipos();
                this.Actual.Fecha_Mantenimiento = DateTime.Today;
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtGuardar()
        {
            try
            {
                if (this.Actual!.Id == 0)
                    this.Actual = this.IMantenimiento_EquiposPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IMantenimiento_EquiposPresentacion.Actualizar(this.Actual!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
            finally
            {
                OnPostBtConsultar();
            }
        }

        public void OnPostBtEditar(string data)
        {
            try
            {
                Formulario = true;
                OnPostBtConsultar();
                this.Actual = this.Lista.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtPregBorrar(string data)
        {
            try
            {
                Borrar = true;
                OnPostBtConsultar();
                this.Actual = this.Lista.FirstOrDefault(x => x.Id == Convert.ToInt32(data));
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
        }

        public void OnPostBtBorrar()
        {
            try
            {
                if (this.Actual!.Id == 0)
                    return;
                this.Actual = this.IMantenimiento_EquiposPresentacion.Borrar(this.Actual!);
            }
            catch (Exception ex)
            {
                LogConversor.Log(ex, ViewData!);
            }
            finally
            {
                OnPostBtConsultar();
            }
        }
    }
}