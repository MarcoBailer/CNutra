using Nutricao.Core.OtherObjects;

namespace Nutricao.Core.Dtos.Refeicao_MVN
{
    public class UpdateRefeicaoDto
    {
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public string Nome { get; set; }
    }
}
