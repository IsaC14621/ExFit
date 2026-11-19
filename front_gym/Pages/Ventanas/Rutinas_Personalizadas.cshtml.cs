using lib_aplicaciones.entidades;
using lib_aplicaciones.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentaciones_Rutinas_Personalizadas.interfaces;

namespace front_gym.Pages.Ventanas
{
    public class Rutinas_PersonalizadasModel : PageModel
    {
        private IRutinas_PersonalizadasPresentacion IRutinas_PersonalizadasPresentacion;

        public Rutinas_PersonalizadasModel(IRutinas_PersonalizadasPresentacion IRutinas_PersonalizadasPresentacion)
        {
            this.IRutinas_PersonalizadasPresentacion = IRutinas_PersonalizadasPresentacion;
            this.Filtro = new Rutinas_Personalizadas();
        }

        [BindProperty] public List<Rutinas_Personalizadas> Lista { get; set; }
        [BindProperty] public Rutinas_Personalizadas? Filtro { get; set; }
        [BindProperty] public Rutinas_Personalizadas? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                Filtro ??= new Rutinas_Personalizadas();
                Lista = this.IRutinas_PersonalizadasPresentacion.Buscar(Filtro!);
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
                this.Actual = new Rutinas_Personalizadas();
                this.Actual.Fecha_Inicio = DateTime.Today;
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
                    this.Actual = this.IRutinas_PersonalizadasPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IRutinas_PersonalizadasPresentacion.Actualizar(this.Actual!);
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
                this.Actual = this.IRutinas_PersonalizadasPresentacion.Borrar(this.Actual!);
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