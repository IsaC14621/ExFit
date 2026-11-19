using lib_aplicaciones.implementaciones;
using lib_aplicaciones.interfaces;
using presentaciones_AsistenciaTrabajadores;
using presentaciones_AsistenciaTrabajadores.interfaces;
using presentaciones_Cargos.interfaces;
using presentaciones_Casilleros.interfaces;
using presentaciones_Clases.interfaces;
using presentaciones_Clientes.interfaces;
using presentaciones_Detalle_Producto.interfaces;
using presentaciones_Dias_Ingreso.interfaces;
using presentaciones_Ejercicios.interfaces;
using presentaciones_gym.implementaciones;
using presentaciones_gym.interfaces;
using presentaciones_Gym.interfaces;
using presentaciones_Logins.interfaces;
using presentaciones_Mantenimiento_Equipos.interfaces;
using presentaciones_Membresias.interfaces;
using presentaciones_Pagos.interfaces;
using presentaciones_Productos.interfaces;
using presentaciones_Proveedores.interfaces;
using presentaciones_Reservas_Clases.interfaces;
using presentaciones_Roles.interfaces;
using presentaciones_Rutinas_Personalizadas.interfaces;
using presentaciones_Tienda.interfaces;
using presentaciones_Tipo_Clases.interfaces;
using presentaciones_Trabajadores.interfaces;
using presentaciones_Usuarios.interfaces;
using presentaciones_Valoraciones_Medicas.interfaces;
using presentaciones_Acceso.interfaces;
using presentaciones_Auditorias.interfaces;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddControllers();
builder.Services.AddScoped<IComunicaciones, Comunicaciones>();
builder.Services.AddScoped<IClientesPresentacion, ClientesPresentacion>();
builder.Services.AddScoped<ITrabajadoresPresentacion, TrabajadoresPresentacion>();
builder.Services.AddScoped<IAsistenciaTrabajadoresPresentacion, AsistenciaTrabajadoresPresentacion>();
builder.Services.AddScoped<ICargosPresentacion, CargosPresentacion>();
builder.Services.AddScoped<ICasillerosPresentacion, CasillerosPresentacion>();
builder.Services.AddScoped<IClasesPresentacion, ClasesPresentacion>();
builder.Services.AddScoped<IDetalle_ProductoPresentacion, Detalle_ProductoPresentacion>();
builder.Services.AddScoped<IProductosPresentacion, ProductosPresentacion>();
builder.Services.AddScoped<ITiendaPresentacion, TiendaPresentacion>();
builder.Services.AddScoped<IProveedoresPresentacion, ProveedoresPresentacion>();
builder.Services.AddScoped<IDias_IngresoPresentacion, Dias_IngresoPresentacion>();
builder.Services.AddScoped<IEjerciciosPresentacion, EjerciciosPresentacion>();
builder.Services.AddScoped<IGymPresentacion, GymPresentacion>();
builder.Services.AddScoped<IMantenimiento_EquiposPresentacion, Mantenimiento_EquiposPresentacion>();
builder.Services.AddScoped<IMembresiasPresentacion, MembresiasPresentacion>();
builder.Services.AddScoped<IPagosPresentacion, PagosPresentacion>();
builder.Services.AddScoped<IReservas_ClasesPresentacion, Reservas_ClasesPresentacion>();
builder.Services.AddScoped<IRutinas_PersonalizadasPresentacion, Rutinas_PersonalizadasPresentacion>();
builder.Services.AddScoped<ITipo_ClasesPresentacion, Tipo_ClasesPresentacion>();
builder.Services.AddScoped<IValoraciones_MedicasPresentacion, Valoraciones_MedicasPresentacion>();
builder.Services.AddScoped<IRolesPresentacion, RolesPresentacion>();
builder.Services.AddScoped<IUsuariosPresentacion, UsuariosPresentacion>();
builder.Services.AddScoped<ILoginsPresentacion, LoginsPresentacion>();
builder.Services.AddScoped<IAccesoPresentacion, AccesoPresentacion>();
builder.Services.AddScoped<IAuditoriasPresentacion, AuditoriasPresentacion>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(o =>
{
    o.IdleTimeout = TimeSpan.FromMinutes(30);
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseSession();

app.Use(async (ctx, next) =>
{
    var path = ctx.Request.Path.Value ?? "";

    // Libres: el login, el logout y los archivos estáticos (css, js, imágenes)
    bool libre = path.StartsWith("/Login", StringComparison.OrdinalIgnoreCase)
              || path.StartsWith("/Logout", StringComparison.OrdinalIgnoreCase)
              || path.StartsWith("/CerrarSesion", StringComparison.OrdinalIgnoreCase)

              || Path.HasExtension(path);

    if (!libre)
    {
        var usuario = ctx.Session.GetString("UsuarioNombre");
        if (string.IsNullOrEmpty(usuario))
        {
            ctx.Response.Redirect("/Login");   // sin sesión: al login
            return;
        }

        // Solo el Administrador entra a Roles, Usuarios y Logins
        var rol = ctx.Session.GetString("Rol");
        bool esAcceso = path.StartsWith("/Ventanas/Roles", StringComparison.OrdinalIgnoreCase)
             || path.StartsWith("/Ventanas/Usuarios", StringComparison.OrdinalIgnoreCase)
             || path.StartsWith("/Ventanas/Logins", StringComparison.OrdinalIgnoreCase)
             || path.StartsWith("/Ventanas/Auditorias", StringComparison.OrdinalIgnoreCase);

        if (esAcceso && rol != "Administrador")
        {
            ctx.Response.Redirect("/");
            return;
        }
    }

    await next();
});
app.UseAuthorization();
app.MapStaticAssets();
app.MapGet("/CerrarSesion", (HttpContext ctx) =>
{
    ctx.Session.Clear();
    return Results.Redirect("/Login");
});
app.MapRazorPages()
   .WithStaticAssets();
app.Run();