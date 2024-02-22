namespace Nutricao.Models
{
    public class RefeicaoMVN
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Carboidratos { get; set; }
        public double Proteinas { get; set; }
        public double Calorias { get; set; }
        public double Lipidios { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public bool IsMatinal { get; set; }
        public bool IsVespertina { get; set; }
        public bool IsNoturna { get; set; }

        public static double CalcularTotalCarboidratos(List<RefeicaoMVN> refeicaoMVN)
        {
            return refeicaoMVN.Sum(r => r.Carboidratos);
        }
        public static double CalcularTotalProteinas(List<RefeicaoMVN> refeicaoMVN)
        {
            return refeicaoMVN.Sum(r => r.Proteinas);
        }
        public static double CalcularTotalCalorias(List<RefeicaoMVN> refeicaoMVN)
        {
            return refeicaoMVN.Sum(r => r.Calorias);
        }
        public static double CalcularTotalLipidios(List<RefeicaoMVN> refeicaoMVN)
        {
            return refeicaoMVN.Sum(r => r.Lipidios);
        }
    }
}
