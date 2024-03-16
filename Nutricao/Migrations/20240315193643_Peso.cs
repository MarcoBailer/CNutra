using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutricao.Migrations
{
    /// <inheritdoc />
    public partial class Peso : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Peso",
                table: "RefeicaoMVN",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Peso",
                table: "RefeicaoMVN");
        }
    }
}
