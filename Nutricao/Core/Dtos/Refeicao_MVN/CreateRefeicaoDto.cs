using Nutricao.Core.OtherObjects;

namespace Nutricao.Core.Dtos.Refeicao
{
    public class CreateRefeicaoDto
    {
        public string Nome { get; set; }
        public int Posicao { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public bool IsMatinal { get; set; } = false;
        public bool IsVespertina { get; set; } = false;
        public bool IsNoturna { get; set; } = false;
    }
}
