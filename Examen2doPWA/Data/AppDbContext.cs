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

            modelBuilder.Entity<Participante>().HasData(
                new Participante
                {
                    Id = 1,
                    Nombre = "Messi",
                    Apellidos = "Leonel",
                    Email = "goat@utleon.edu.mx",
                    UsuarioTwitter = "https://x.com/leomessisite?lang=es",
                    Ocupacion = "Desarrollador Full Stack",
                    Avatar = "https://fifpro.org/media/5chb3dva/lionel-messi_imago1019567000h.jpg?rxy=0.32986930611281567,0.18704579979466449&rnd=133378758718600000",
                    FechaRegistro = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Participante
                {
                    Id = 2,
                    Nombre = "CR7",
                    Apellidos = "Penaldo",
                    Email = "penaldo@utleon.edu.mx",
                    UsuarioTwitter = "https://x.com/Cristiano",
                    Ocupacion = "Generador de penales",
                    Avatar = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTAWRTlPgbJmYTdG6UEyeU9cUlBlHHcpccfDEPuM8PRDSoioEf-fquWcWsyfbLCv-w9Mpv4RbHmzauIabXPWce7uzXiGyvkveXkELLUr0Q&s=10",
                    FechaRegistro = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                },
                new Participante
                {
                    Id = 3,
                    Nombre = "balderas",
                    Apellidos = "Sanchez",
                    Email = "78643@utleon.edu.mx",
                    UsuarioTwitter = "https://x.com/NachoAmbriz1",
                    Ocupacion = "DevOps Engineer",
                    Avatar = "https://www.infobae.com/resizer/v2/UPGSJ35VNJDRFI6Y3II4QNQYVE.jpg?auth=e000c19b39b8d9fd3742fba0f250e843d8c3d38f14e62d49b70643278f9ee4a6&smart=true&width=350&height=197&quality=85",
                    FechaRegistro = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                }
            );
        }
    }
}