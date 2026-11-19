using lib_aplicaciones.entidades;
using lib_aplicaciones.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentaciones_Valoraciones_Medicas.interfaces;

namespace front_gym.Pages.Ventanas
{
    public class Valoraciones_MedicasModel : PageModel
    {
        private IValoraciones_MedicasPresentacion IValoraciones_MedicasPresentacion;

        public Valoraciones_MedicasModel(IValoraciones_MedicasPresentacion IValoraciones_MedicasPresentacion)
        {
            this.IValoraciones_MedicasPresentacion = IValoraciones_MedicasPresentacion;
            this.Filtro = new Valoraciones_Medicas();
        }

        [BindProperty] public List<Valoraciones_Medicas> Lista { get; set; }
        [BindProperty] public Valoraciones_Medicas? Filtro { get; set; }
        [BindProperty] public Valoraciones_Medicas? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                Filtro ??= new Valoraciones_Medicas();
                Lista = this.IValoraciones_MedicasPresentacion.Buscar(Filtro!);
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
                this.Actual = new Valoraciones_Medicas();
                this.Actual.Fecha_Evaluacion = DateTime.Today;
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
                    this.Actual = this.IValoraciones_MedicasPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IValoraciones_MedicasPresentacion.Actualizar(this.Actual!);
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
                this.Actual = this.IValoraciones_MedicasPresentacion.Borrar(this.Actual!);
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
