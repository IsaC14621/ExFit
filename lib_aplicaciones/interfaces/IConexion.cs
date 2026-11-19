using lib_aplicaciones.entidades;
using lib_aplicaciones.implementaciones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;


namespace Libreria.Interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }


        DbSet<AsistenciaTrabajadores>? AsistenciaTrabajadores { get; set; }
        DbSet<Cargos>? Cargos { get; set; }
        DbSet<Casilleros>? Casilleros { get; set; }
        DbSet<Clases>? Clases { get; set; }
        DbSet<Clientes>? Clientes { get; set; }
        DbSet<Detalle_Producto>? Detalle_Producto { get; set; }
        DbSet<Dias_Ingreso>? Dias_Ingreso { get; set; }
        DbSet<Ejercicios>? Ejercicios { get; set; }
        DbSet<Gym>? Gym { get; set; }
        DbSet<Mantenimiento_Equipos>? Mantenimiento_Equipos { get; set; }
        DbSet<Membresias>? Membresias { get; set; }
        DbSet<Pagos>? Pagos { get; set; }
        DbSet<Productos>? Productos { get; set; }
        DbSet<Proveedores>? Proveedores { get; set; }
        DbSet<Reservas_Clases>? Reservas_Clases { get; set; }
        DbSet<Rutinas_Personalizadas>? Rutinas_Personalizadas { get; set; }
        DbSet<Tienda>? Tienda { get; set; }
        DbSet<Tipo_Clases> Tipo_Clases { get; set; }
        DbSet<Trabajadores>? Trabajadores { get; set; }
        DbSet<Roles> Roles { get; set; }
        DbSet<Usuarios> Usuarios { get; set; }
        DbSet<Logins> Logins { get; set; }

        DbSet<Valoraciones_Medicas>? Valoraciones_Medicas { get; set; }
        DbSet<Auditorias>? Auditorias{ get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}