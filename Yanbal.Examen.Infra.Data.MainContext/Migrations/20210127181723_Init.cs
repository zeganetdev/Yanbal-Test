using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Yanbal.Examen.Infra.Data.MainContext.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "Id", "Activo", "Apellidos", "Correo", "Direccion", "FechaNacimiento", "FechaRegistro", "Nombres" },
                values: new object[,]
                {
                    { 1, true, "Alcantara", "carlos@dominio.com", null, null, new DateTime(2021, 1, 27, 13, 17, 22, 481, DateTimeKind.Local).AddTicks(8304), "Carlos" },
                    { 2, true, "Reyes", "luis@dominio.com", null, null, new DateTime(2021, 1, 27, 13, 17, 22, 482, DateTimeKind.Local).AddTicks(9827), "Luis" },
                    { 3, true, "Pinillos", "marcos1@dominio.com", null, null, new DateTime(2021, 1, 27, 13, 17, 22, 482, DateTimeKind.Local).AddTicks(9867), "Marcos" },
                    { 4, true, "Buis", "marcos2@dominio.com", null, null, new DateTime(2021, 1, 27, 13, 17, 22, 482, DateTimeKind.Local).AddTicks(9870), "Marcos" },
                    { 5, true, "Coronel", "alberto@dominio.com", null, null, new DateTime(2021, 1, 27, 13, 17, 22, 482, DateTimeKind.Local).AddTicks(9872), "Alberto" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Correo",
                table: "Cliente",
                column: "Correo",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
