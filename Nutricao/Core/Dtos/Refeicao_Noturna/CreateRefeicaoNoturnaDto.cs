namespace Nutricao.Core.Dtos.Refeicao_Noturna
{
    public class CreateRefeicaoNoturnaDto
    {
        public string Nome { get; set; }
        public double Carboidratos { get; set; }
        public double Proteinas { get; set; }
        public double Calorias { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
    }
}
