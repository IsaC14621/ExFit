using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using lib_aplicaciones.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentaciones_Dias_Ingreso.interfaces;

namespace front_gym.Pages.Ventanas
{
    public class Dias_IngresoModel : PageModel
    {
        private IDias_IngresoPresentacion IDias_IngresoPresentacion;

        public Dias_IngresoModel(IDias_IngresoPresentacion IDias_IngresoPresentacion)
        {
            this.IDias_IngresoPresentacion = IDias_IngresoPresentacion;
            this.Filtro = new Dias_Ingreso();
        }

        [BindProperty] public List<Dias_Ingreso> Lista { get; set; } = new List<Dias_Ingreso>();
        [BindProperty] public Dias_Ingreso? Filtro { get; set; }
        [BindProperty] public Dias_Ingreso? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                Filtro!.Tipo_Membresia = Filtro!.Tipo_Membresia ?? "";
                Lista = this.IDias_IngresoPresentacion.Buscar(Filtro!);
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
                this.Actual = new Dias_Ingreso();
                this.Actual.Hora_ingreso = DateTime.Now;
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
                    this.Actual = this.IDias_IngresoPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IDias_IngresoPresentacion.Actualizar(this.Actual!);
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
                this.Actual = this.IDias_IngresoPresentacion.Borrar(this.Actual!);
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