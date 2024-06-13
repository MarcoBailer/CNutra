namespace Nutricao.Core.Dtos.Refeicao_MVN
{
    public class ReadRefeicaoDto
    {
        public string Nome { get; set; }
        public int Posicao { get; set; }
        public double Carboidratos { get; set; }
        public double Proteinas { get; set; }
        public double Lipidios { get; set; }
        public double Fibra { get; set; }
        public double Calorias { get; set; }
        public int Peso { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public bool IsMatinal { get; set; }
        public bool IsVespertina { get; set; }
        public bool IsNoturna { get; set; }
    }
}
