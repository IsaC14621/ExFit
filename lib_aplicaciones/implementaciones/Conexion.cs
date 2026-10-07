
using lib_aplicaciones.entidades;
using Libreria.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria.implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Asistencia_Trabajadores>? Asistencia_Trabajadores{ get; set; }
        public DbSet<Cargos>?   Cargos { get; set; }
        public DbSet<Casilleros>?  Casilleros { get; set; }
        public DbSet<Clases>? Clases { get; set; }
        public DbSet<Clientes>? Clientes { get; set; }
        public DbSet<Detalle_Producto>? Detalle_Producto { get; set; }
        public DbSet<Dias_Ingreso>? Dias_Ingresos{ get; set; }
        public DbSet<Ejercicio>? Ejercicios { get; set; }
        public DbSet<Gym>? Gym { get; set; }
        public DbSet<Mantenimiento_Equipos>? Mantenimiento_Equipos { get; set; }
        public DbSet<Membresias>? Membresias { get; set; }
        public DbSet<Pagos>? Pagos { get; set; }
        public DbSet<Productos>? Productos{ get; set; }
        public DbSet<Proveedores>? Proveedores { get; set; }
        public DbSet<Reservas_Clases>? Reservas_Clases { get; set; }
        public DbSet<Rutinas_Personalizadas>? Rutinas_Personalizadas { get; set; }
        public DbSet<Tienda>? Tienda { get; set; }
        public DbSet<Tipo_Clases>? Tipo_Clases { get; set; }
        public DbSet<Trabajadores>? Trabajadores { get; set; }
        public DbSet<Valoraciones_Medicas>? Valoraciones_Medicas { get; set; }
        public DbSet<Dias_Ingreso>? Dias_Ingreso { get; set; }
        
    }
}
