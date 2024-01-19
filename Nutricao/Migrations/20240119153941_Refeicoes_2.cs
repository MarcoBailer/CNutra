using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutricao.Migrations
{
    /// <inheritdoc />
    public partial class Refeicoes_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Lipidios",
                table: "RefeicaoVespertina",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "RefeicaoVespertina",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Lipidios",
                table: "RefeicaoNoturna",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "RefeicaoNoturna",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Lipidios",
                table: "RefeicaoMatinal",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "RefeicaoMatinal",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lipidios",
                table: "RefeicaoVespertina");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "RefeicaoVespertina");

            migrationBuilder.DropColumn(
                name: "Lipidios",
                table: "RefeicaoNoturna");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "RefeicaoNoturna");

            migrationBuilder.DropColumn(
                name: "Lipidios",
                table: "RefeicaoMatinal");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "RefeicaoMatinal");
        }
    }
}
