using lib_aplicaciones.entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using presentaciones_Acceso.interfaces;

namespace front_gym.Pages
{
    public class LoginModel : PageModel
    {
        private IAccesoPresentacion IAccesoPresentacion;

        public LoginModel(IAccesoPresentacion IAccesoPresentacion)
        {
            this.IAccesoPresentacion = IAccesoPresentacion;
        }

        [BindProperty] public string? Correo { get; set; }
        [BindProperty] public string? Contrasena { get; set; }
        public string? Error { get; set; }

        public void OnGet()
        {
            HttpContext.Session.Clear();
        }

        public IActionResult OnPost()
        {
            try
            {
                var usuario = this.IAccesoPresentacion.Ingresar(new Credenciales
                {
                    Correo = Correo,
                    Contrasena = Contrasena
                });

                HttpContext.Session.SetInt32("UsuarioId", usuario.Id);
                HttpContext.Session.SetString("UsuarioNombre", usuario.Nombre ?? "");
                HttpContext.Session.SetString("Rol", usuario._Rol?.Nombre ?? "");

                return RedirectToPage("/Index");
            }
            catch (Exception)
            {
                Error = "Correo o contraseña incorrectos (o el servicio no está disponible).";
                return Page();
            }
        }
    }
}