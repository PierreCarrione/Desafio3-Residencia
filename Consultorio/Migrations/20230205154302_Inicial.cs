using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ConsultorioProject.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pacientes",
                columns: table => new
                {
                    cpf = table.Column<string>(type: "text", nullable: false),
                    nome = table.Column<string>(type: "text", nullable: false),
                    datanasc = table.Column<DateTime>(name: "data_nasc", type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_pacientes", x => x.cpf);
                });

            migrationBuilder.CreateTable(
                name: "agendamentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pacientecpf = table.Column<string>(name: "paciente_cpf", type: "text", nullable: false),
                    dataconsulta = table.Column<DateTime>(name: "data_consulta", type: "timestamp with time zone", nullable: false),
                    horainicial = table.Column<TimeSpan>(name: "hora_inicial", type: "interval", nullable: false),
                    horafinal = table.Column<TimeSpan>(name: "hora_final", type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_agendamentos", x => x.id);
                    table.ForeignKey(
                        name: "fk_agendamentos_pacientes_paciente_cpf",
                        column: x => x.pacientecpf,
                        principalTable: "pacientes",
                        principalColumn: "cpf",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_agendamentos_paciente_cpf",
                table: "agendamentos",
                column: "paciente_cpf");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "agendamentos");

            migrationBuilder.DropTable(
                name: "pacientes");
        }
    }
}
