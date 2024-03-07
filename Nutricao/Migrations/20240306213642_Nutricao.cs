using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutricao.Migrations
{
    /// <inheritdoc />
    public partial class Nutricao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Refeicao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalCarboidratos = table.Column<double>(type: "float", nullable: false),
                    TotalProteinas = table.Column<double>(type: "float", nullable: false),
                    TotalGorduras = table.Column<double>(type: "float", nullable: false),
                    TotalCalorias = table.Column<double>(type: "float", nullable: false),
                    TotalFibras = table.Column<double>(type: "float", nullable: false),
                    Dia = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refeicao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefeicaoMVN",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Carboidratos = table.Column<double>(type: "float", nullable: false),
                    Proteinas = table.Column<double>(type: "float", nullable: false),
                    Calorias = table.Column<double>(type: "float", nullable: false),
                    Lipidios = table.Column<double>(type: "float", nullable: false),
                    Fibra = table.Column<double>(type: "float", nullable: false),
                    Dia = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    IsMatinal = table.Column<bool>(type: "bit", nullable: false),
                    IsVespertina = table.Column<bool>(type: "bit", nullable: false),
                    IsNoturna = table.Column<bool>(type: "bit", nullable: false),
                    Posicao = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefeicaoMVN", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Refeicao");

            migrationBuilder.DropTable(
                name: "RefeicaoMVN");
        }
    }
}
