using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nutricao.Domain.Configuration.Models.Auth;
using Nutricao.Models;

namespace Nutricao.Core.Dtos.Context
{
    public class RefeicaoContext : IdentityDbContext<ApplicationUser>
    {
        public RefeicaoContext(DbContextOptions<RefeicaoContext> options) : base(options)
        {
        }

        public DbSet<RefeicaoMVN> RefeicaoMVN { get; set; }
        public DbSet<CalculoDaRefeicao> Refeicao { get; set; }
        public DbSet<CalculoDaRefeicaoPorPosicao> RefeicaoPosicao { get; set; }
        public DbSet<CalculoDaRefeicaoPorTurno> RefeicaoTurno { get; set; }
        public DbSet<User> Usuarios { get; set; }
    }
}
