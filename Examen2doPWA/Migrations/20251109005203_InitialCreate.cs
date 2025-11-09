using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 

namespace Examen2doPWA.Migrations
{
   
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Participantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Apellidos = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    UsuarioTwitter = table.Column<string>(type: "TEXT", nullable: false),
                    Ocupacion = table.Column<string>(type: "TEXT", nullable: false),
                    Avatar = table.Column<string>(type: "TEXT", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participantes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Participantes",
                columns: new[] { "Id", "Apellidos", "Avatar", "Email", "FechaRegistro", "Nombre", "Ocupacion", "UsuarioTwitter" },
                values: new object[,]
                {
                    { 1, "Leonel", "https://fifpro.org/media/5chb3dva/lionel-messi_imago1019567000h.jpg?rxy=0.32986930611281567,0.18704579979466449&rnd=133378758718600000", "goat@utleon.edu.mx", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Messi", "Desarrollador Full Stack", "https://x.com/leomessisite?lang=es" },
                    { 2, "Penaldo", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTAWRTlPgbJmYTdG6UEyeU9cUlBlHHcpccfDEPuM8PRDSoioEf-fquWcWsyfbLCv-w9Mpv4RbHmzauIabXPWce7uzXiGyvkveXkELLUr0Q&s=10", "penaldo@utleon.edu.mx", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "CR7", "Generador de penales", "https://x.com/Cristiano" },
                    { 3, "Sanchez", "https://www.infobae.com/resizer/v2/UPGSJ35VNJDRFI6Y3II4QNQYVE.jpg?auth=e000c19b39b8d9fd3742fba0f250e843d8c3d38f14e62d49b70643278f9ee4a6&smart=true&width=350&height=197&quality=85", "78643@utleon.edu.mx", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "balderas", "DevOps Engineer", "https://x.com/NachoAmbriz1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Participantes");
        }
    }
}
