using Microsoft.EntityFrameworkCore;
using Examen2doPWA.Models;
using System;

namespace Examen2doPWA.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Participante> Participantes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<Participante>().HasData(
                new Participante
                {
                    Id = 1,
                    Nombre = "Carlos",
                    Apellidos = "García López",
                    Email = "carlos.garcia@utleon.edu.mx",
                    UsuarioTwitter = "@CarlosGL",
                    Ocupacion = "Desarrollador Full Stack",
                    Avatar = "https://i.pravatar.cc/150?img=12",
                    FechaRegistro = DateTime.UtcNow
                },
                new Participante
                {
                    Id = 2,
                    Nombre = "María",
                    Apellidos = "Rodríguez Pérez",
                    Email = "maria.rodriguez@utleon.edu.mx",
                    UsuarioTwitter = "@MariaRP",
                    Ocupacion = "Data Scientist",
                    Avatar = "https://i.pravatar.cc/150?img=45",
                    FechaRegistro = DateTime.UtcNow
                },
                new Participante
                {
                    Id = 3,
                    Nombre = "Juan",
                    Apellidos = "Martínez Sánchez",
                    Email = "juan.martinez@utleon.edu.mx",
                    UsuarioTwitter = "@JuanMS",
                    Ocupacion = "DevOps Engineer",
                    Avatar = "https://i.pravatar.cc/150?img=33",
                    FechaRegistro = DateTime.UtcNow
                }
            );
        }
    }
}