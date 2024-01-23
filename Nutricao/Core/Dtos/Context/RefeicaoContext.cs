using Microsoft.EntityFrameworkCore;
using Nutricao.Models;

namespace Nutricao.Core.Dtos.Context
{
    public class RefeicaoContext : DbContext
    {
        public RefeicaoContext(DbContextOptions<RefeicaoContext> options) : base(options)
        {
        }

        public DbSet<RefeicaoMatinal> RefeicaoMatinal { get; set; }
        public DbSet<RefeicaoVespertina> RefeicaoVespertina { get; set; }
        public DbSet<RefeicaoNoturna> RefeicaoNoturna { get; set; }
        public DbSet<CalculoDaRefeicao> Refeicao { get; set; }
    }
}
