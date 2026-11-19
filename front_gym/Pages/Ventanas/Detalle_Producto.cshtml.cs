using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;
using lib_aplicaciones.nucleo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentaciones_Detalle_Producto.interfaces;

namespace front_gym.Pages.Ventanas
{
    public class Detalle_ProductoModel : PageModel
    {
        private IDetalle_ProductoPresentacion IDetalle_ProductoPresentacion;

        public Detalle_ProductoModel(IDetalle_ProductoPresentacion IDetalle_ProductoPresentacion)
        {
            this.IDetalle_ProductoPresentacion = IDetalle_ProductoPresentacion;
            this.Filtro = new Detalle_Producto();
        }

        [BindProperty] public List<Detalle_Producto> Lista { get; set; } = new List<Detalle_Producto>();
        [BindProperty] public Detalle_Producto? Filtro { get; set; }
        [BindProperty] public Detalle_Producto? Actual { get; set; }
        [BindProperty] public bool Formulario { get; set; } = false;
        [BindProperty] public bool Borrar { get; set; } = false;

        public void OnGet() { OnPostBtConsultar(); }

        public void OnPostBtConsultar()
        {
            try
            {
                Filtro ??= new Detalle_Producto();
                Lista = this.IDetalle_ProductoPresentacion.Buscar(Filtro);
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
                this.Actual = new Detalle_Producto();
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
                    this.Actual = this.IDetalle_ProductoPresentacion.Insertar(this.Actual!);
                else
                    this.Actual = this.IDetalle_ProductoPresentacion.Actualizar(this.Actual!);
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
                this.Actual = this.IDetalle_ProductoPresentacion.Borrar(this.Actual!);
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
