using Nutricao.Core.OtherObjects;

namespace Nutricao.Core.Dtos.Refeicao
{
    public class UpdateRefeicaoDto
    {
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public bool IsMatinal { get; set; }
        public bool IsVespertina { get; set; }
        public bool IsNoturna { get; set; }
    }
}
