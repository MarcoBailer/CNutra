using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutricao.Migrations
{
    /// <inheritdoc />
    public partial class Refeicoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RefeicaoMatinal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Carboidratos = table.Column<double>(type: "float", nullable: false),
                    Proteinas = table.Column<double>(type: "float", nullable: false),
                    Calorias = table.Column<double>(type: "float", nullable: false),
                    Dia = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefeicaoMatinal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefeicaoNoturna",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Carboidratos = table.Column<double>(type: "float", nullable: false),
                    Proteinas = table.Column<double>(type: "float", nullable: false),
                    Calorias = table.Column<double>(type: "float", nullable: false),
                    Dia = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefeicaoNoturna", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefeicaoVespertina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Carboidratos = table.Column<double>(type: "float", nullable: false),
                    Proteinas = table.Column<double>(type: "float", nullable: false),
                    Calorias = table.Column<double>(type: "float", nullable: false),
                    Dia = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefeicaoVespertina", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefeicaoMatinal");

            migrationBuilder.DropTable(
                name: "RefeicaoNoturna");

            migrationBuilder.DropTable(
                name: "RefeicaoVespertina");
        }
    }
}
