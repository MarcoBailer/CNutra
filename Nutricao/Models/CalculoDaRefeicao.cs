using System.ComponentModel.DataAnnotations;

namespace Nutricao.Models
{
    public class CalculoDaRefeicao
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public double TotalCarboidratos { get; set; }
        public double TotalProteinas { get; set; }
        public double TotalGorduras { get; set; }
        public double TotalCalorias { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public static double CalcularTotalCarboidratos(List<RefeicaoMatinal> matinal, List<RefeicaoVespertina> vespertina, List<RefeicaoNoturna> noturna)
        {
            return 
                RefeicaoMatinal.CalcularTotalCarboidratosMatinal(matinal) + RefeicaoVespertina.CalcularTotalCarboidratosVespertina(vespertina) + RefeicaoNoturna.CalcularTotalCarboidratosNoturna(noturna);
        }
        public static double CalcularTotalProteinas(List<RefeicaoMatinal> matinal, List<RefeicaoVespertina> vespertina, List<RefeicaoNoturna> noturna)
        {
            return 
                RefeicaoMatinal.CalcularTotalProteinasMatinal(matinal) + RefeicaoVespertina.CalcularTotalProteinasVespertina(vespertina) + RefeicaoNoturna.CalcularTotalProteinasNoturna(noturna);
        }
        public static double CalcularTotalGorduras(List<RefeicaoMatinal> matinal, List<RefeicaoVespertina> vespertina, List<RefeicaoNoturna> noturna)
        {
            return 
                RefeicaoMatinal.CalcularTotalLipidiosMatinal(matinal) + RefeicaoVespertina.CalcularTotalLipidiosVespertina(vespertina) + RefeicaoNoturna.CalcularTotalLipidiosNoturna(noturna);
        }
        public static double CalcularTotalCalorias(List<RefeicaoMatinal> matinal, List<RefeicaoVespertina> vespertina, List<RefeicaoNoturna> noturna)
        {
            return 
                RefeicaoMatinal.CalcularTotalCaloriasMatinal(matinal) + RefeicaoVespertina.CalcularTotalCaloriasVespertina(vespertina) + RefeicaoNoturna.CalcularTotalCaloriasNoturna(noturna);
        }
    }

}
