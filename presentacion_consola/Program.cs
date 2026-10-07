
using Libreria.Interfaces;
using Libreria.implementaciones;

try
{
    IConexion conexion = new Conexion();
    conexion.StringConexion = "server=localhost;database=Ex_Fit;Integrated Security=True;TrustServerCertificate=true;";
    var lista_Gym = conexion.Cargos!.ToList();
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}

Console.WriteLine("presentacion_consola");
