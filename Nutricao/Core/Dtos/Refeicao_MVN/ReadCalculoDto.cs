namespace Nutricao.Core.Dtos.Refeicao_MVN
{
    public class ReadCalculoDto
    {
        public double TotalCarboidratos { get; set; }
        public double TotalProteinas { get; set; }
        public double TotalGorduras { get; set; }
        public double TotalCalorias { get; set; }
        public double TotalFibras { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
    }
}
