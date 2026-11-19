/*using lib_aplicaciones.interfaces;
using Libreria.implementaciones;
using Libreria.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IConexion, Conexion>();
builder.Services.AddScoped<IClientesAplicacion, ClientesAplicacion>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/", () => "");
app.Run();
*/
using lib_aplicaciones.implementaciones;
using lib_aplicaciones.interfaces;
using Libreria.implementaciones;
using Libreria.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IConexion>(provider =>
{
    var conexion = new Conexion();

    conexion.StringConexion =
        builder.Configuration.GetConnectionString("Conexion");

    return conexion;
});

builder.Services.AddScoped<IClientesAplicacion, ClientesAplicacion>();
builder.Services.AddScoped<ITrabajadoresAplicacion, TrabajadoresAplicacion>();
builder.Services.AddScoped<IAsistenciaTrabajadoresAplicacion, AsistenciaTrabajadoresAplicacion>();
builder.Services.AddScoped<ICargosAplicacion, CargosAplicacion>();
builder.Services.AddScoped<ICasillerosAplicacion, CasillerosAplicacion>();
builder.Services.AddScoped<IClasesAplicacion, ClasesAplicacion>();
builder.Services.AddScoped<IDetalle_ProductoAplicacion, Detalle_ProductoAplicacion>();
builder.Services.AddScoped<IProductosAplicacion, ProductosAplicacion>();
builder.Services.AddScoped<ITiendaAplicacion, TiendaAplicacion>();
builder.Services.AddScoped<IProveedoresAplicacion, ProveedoresAplicacion>();
builder.Services.AddScoped<IDias_IngresoAplicacion, Dias_IngresoAplicacion>();
builder.Services.AddScoped<IEjerciciosAplicacion, EjerciciosAplicacion>();
builder.Services.AddScoped<IGymAplicacion, GymAplicacion>();
builder.Services.AddScoped<IMantenimiento_EquiposAplicacion, Mantenimiento_EquiposAplicacion>();
builder.Services.AddScoped<IMembresiasAplicacion, MembresiasAplicacion>();
builder.Services.AddScoped<IPagosAplicacion, PagosAplicacion>();
builder.Services.AddScoped<IReservas_ClasesAplicacion, Reservas_ClasesAplicacion>();
builder.Services.AddScoped<IRutinas_PersonalizadasAplicacion, Rutinas_PersonalizadasAplicacion>();
builder.Services.AddScoped<ITipo_ClasesAplicacion, Tipo_ClasesAplicacion>();
builder.Services.AddScoped<IValoraciones_MedicasAplicacion, Valoraciones_MedicasAplicacion>();
builder.Services.AddScoped<IRolesAplicacion, RolesAplicacion>();
builder.Services.AddScoped<IUsuariosAplicacion, UsuariosAplicacion>();
builder.Services.AddScoped<ILoginsAplicacion, LoginsAplicacion>();
builder.Services.AddScoped<IAccesoAplicacion, AccesoAplicacion>();
builder.Services.AddScoped<IAuditoriasAplicacion, AuditoriasAplicacion>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapGet("/", () => "");
app.Run();