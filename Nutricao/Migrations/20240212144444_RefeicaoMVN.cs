using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutricao.Migrations
{
    /// <inheritdoc />
    public partial class RefeicaoMVN : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefeicaoMatinal");

            migrationBuilder.DropTable(
                name: "RefeicaoNoturna");

            migrationBuilder.DropTable(
                name: "RefeicaoVespertina");

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
                    Dia = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    IsMatinal = table.Column<bool>(type: "bit", nullable: false),
                    IsVespertina = table.Column<bool>(type: "bit", nullable: false),
                    IsNoturna = table.Column<bool>(type: "bit", nullable: false)
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
                name: "RefeicaoMVN");

            migrationBuilder.CreateTable(
                name: "RefeicaoMatinal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Calorias = table.Column<double>(type: "float", nullable: false),
                    Carboidratos = table.Column<double>(type: "float", nullable: false),
                    Dia = table.Column<int>(type: "int", nullable: false),
                    Lipidios = table.Column<double>(type: "float", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Proteinas = table.Column<double>(type: "float", nullable: false)
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
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Calorias = table.Column<double>(type: "float", nullable: false),
                    Carboidratos = table.Column<double>(type: "float", nullable: false),
                    Dia = table.Column<int>(type: "int", nullable: false),
                    Lipidios = table.Column<double>(type: "float", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Proteinas = table.Column<double>(type: "float", nullable: false)
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
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Calorias = table.Column<double>(type: "float", nullable: false),
                    Carboidratos = table.Column<double>(type: "float", nullable: false),
                    Dia = table.Column<int>(type: "int", nullable: false),
                    Lipidios = table.Column<double>(type: "float", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Proteinas = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefeicaoVespertina", x => x.Id);
                });
        }
    }
}
