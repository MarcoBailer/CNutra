using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutricao.Migrations
{
    /// <inheritdoc />
    public partial class Calculos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefeicaoPosicao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalCarboidratos = table.Column<double>(type: "float", nullable: false),
                    TotalProteinas = table.Column<double>(type: "float", nullable: false),
                    TotalGorduras = table.Column<double>(type: "float", nullable: false),
                    TotalCalorias = table.Column<double>(type: "float", nullable: false),
                    TotalFibras = table.Column<double>(type: "float", nullable: false),
                    Posicao = table.Column<int>(type: "int", nullable: false),
                    Dia = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefeicaoPosicao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefeicaoTurno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalCarboidratos = table.Column<double>(type: "float", nullable: false),
                    TotalProteinas = table.Column<double>(type: "float", nullable: false),
                    TotalGorduras = table.Column<double>(type: "float", nullable: false),
                    TotalCalorias = table.Column<double>(type: "float", nullable: false),
                    TotalFibras = table.Column<double>(type: "float", nullable: false),
                    IsMatinal = table.Column<bool>(type: "bit", nullable: false),
                    IsVespertina = table.Column<bool>(type: "bit", nullable: false),
                    IsNoturna = table.Column<bool>(type: "bit", nullable: false),
                    Dia = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefeicaoTurno", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefeicaoPosicao");

            migrationBuilder.DropTable(
                name: "RefeicaoTurno");
        }
    }
}
