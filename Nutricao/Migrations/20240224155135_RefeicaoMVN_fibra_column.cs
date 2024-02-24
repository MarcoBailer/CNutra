using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutricao.Migrations
{
    /// <inheritdoc />
    public partial class RefeicaoMVN_fibra_column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Fibra",
                table: "RefeicaoMVN",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "TotalFibras",
                table: "Refeicao",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fibra",
                table: "RefeicaoMVN");

            migrationBuilder.DropColumn(
                name: "TotalFibras",
                table: "Refeicao");
        }
    }
}
