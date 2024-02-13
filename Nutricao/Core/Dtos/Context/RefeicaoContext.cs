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
    }
}
