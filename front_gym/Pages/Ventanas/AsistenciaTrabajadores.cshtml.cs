using lib_aplicaciones.entidades;
using lib_aplicaciones.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentaciones_AsistenciaTrabajadores.interfaces;

namespace front_gym.Pages.Ventanas
{
    public class AsistenciaTrabajadoresModel : PageModel
    {
        private IAsistenciaTrabajadoresPresentacion IAsistenciaTrabajadoresPresentacion;

        public AsistenciaTrabajadoresModel(IAsistenciaTrabajadoresPresentacion IAsistenciaTrabajadoresPresentacion)
        {
            this.IAsistenciaTrabajadoresPresentacion = IAsistenciaTrabajadoresPresentacion;
            this.Filtro = new AsistenciaTrabajadores();
        }

        [BindProperty] public List<AsistenciaTrabajadores> Lista { get; set; }
        [BindProperty] public AsistenciaTrabajadores? Filtro { get; set; }
        [BindProperty] public AsistenciaTrabajadores? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                Filtro ??= new AsistenciaTrabajadores();
                Lista = this.IAsistenciaTrabajadoresPresentacion.Buscar(Filtro!);
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
                this.Actual = new AsistenciaTrabajadores();
                this.Actual.Fecha = DateTime.Today;
                this.Actual.Hora_Entrada = DateTime.Now;
                this.Actual.Hora_Salida = DateTime.Now;
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
                    this.Actual = this.IAsistenciaTrabajadoresPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IAsistenciaTrabajadoresPresentacion.Actualizar(this.Actual!);
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
                this.Actual = this.IAsistenciaTrabajadoresPresentacion.Borrar(this.Actual!);
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