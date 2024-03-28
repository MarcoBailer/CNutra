using Microsoft.EntityFrameworkCore;
using Nutricao.Models;

namespace Nutricao.Core.Dtos.Context
{
    public class RefeicaoContext : DbContext
    {
        public RefeicaoContext(DbContextOptions<RefeicaoContext> options) : base(options)
        {
        }

        public DbSet<RefeicaoMVN> RefeicaoMVN { get; set; }
        public DbSet<CalculoDaRefeicao> Refeicao { get; set; }
        public DbSet<CalculoDaRefeicaoPorPosicao> RefeicaoPosicao { get; set; }
        public DbSet<CalculoDaRefeicaoPorTurno> RefeicaoTurno { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
