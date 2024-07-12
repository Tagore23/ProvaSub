using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    AlunoId = table.Column<string>(type: "TEXT", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: true),
                    Altura = table.Column<double>(type: "REAL", nullable: false),
                    Peso = table.Column<double>(type: "REAL", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.AlunoId);
                });

            migrationBuilder.CreateTable(
                name: "IMCs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AlunoId = table.Column<string>(type: "TEXT", nullable: false),
                    Peso = table.Column<decimal>(type: "TEXT", nullable: false),
                    Altura = table.Column<decimal>(type: "TEXT", nullable: false),
                    ValorIMC = table.Column<decimal>(type: "TEXT", nullable: false),
                    Classificacao = table.Column<string>(type: "TEXT", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMCs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IMCs_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "AlunoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "AlunoId", "Altura", "CriadoEm", "Nome", "Peso", "Sobrenome" },
                values: new object[,]
                {
                    { "6d091456-5a2f-4b5a-98fc-f1a3b50a627d", 1.75, new DateTime(2024, 7, 12, 11, 1, 15, 509, DateTimeKind.Local).AddTicks(2852), "João", 70.0, "Silva" },
                    { "bfe4e7dc-81e4-4e47-a67b-d4fbf3e124bd", 1.6499999999999999, new DateTime(2024, 7, 12, 11, 1, 15, 509, DateTimeKind.Local).AddTicks(2858), "Maria", 60.0, "Oliveira" }
                });

            migrationBuilder.InsertData(
                table: "IMCs",
                columns: new[] { "Id", "Altura", "AlunoId", "Classificacao", "DataCriacao", "Peso", "ValorIMC" },
                values: new object[,]
                {
                    { 1, 1.75m, "6d091456-5a2f-4b5a-98fc-f1a3b50a627d", "Normal", new DateTime(2024, 7, 12, 14, 1, 15, 509, DateTimeKind.Utc).AddTicks(3037), 70.0m, 22.857142857142857142857142857m },
                    { 2, 1.65m, "bfe4e7dc-81e4-4e47-a67b-d4fbf3e124bd", "Normal", new DateTime(2024, 7, 12, 14, 1, 15, 509, DateTimeKind.Utc).AddTicks(3040), 60.0m, 22.038567493112947658402203857m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IMCs_AlunoId",
                table: "IMCs",
                column: "AlunoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IMCs");

            migrationBuilder.DropTable(
                name: "Alunos");
        }
    }
}
