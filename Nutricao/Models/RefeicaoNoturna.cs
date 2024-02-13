using System.ComponentModel.DataAnnotations;

namespace Nutricao.Models
{
    public class RefeicaoNoturna
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Carboidratos { get; set; }
        public double Proteinas { get; set; }
        public double Calorias { get; set; }
        public double Lipidios { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }

        public static double CalcularTotalCarboidratosNoturna(List<RefeicaoNoturna> refeicaoNoturna)
        {
            return refeicaoNoturna.Sum(r => r.Carboidratos);
        }
        public static double CalcularTotalProteinasNoturna(List<RefeicaoNoturna> refeicaoNoturna)
        {
            return refeicaoNoturna.Sum(r => r.Proteinas);
        }
        public static double CalcularTotalCaloriasNoturna(List<RefeicaoNoturna> refeicaoNoturna)
        {
            return refeicaoNoturna.Sum(r => r.Calorias);
        }
        public static double CalcularTotalLipidiosNoturna(List<RefeicaoNoturna> refeicaoNoturna)
        {
            return refeicaoNoturna.Sum(r => r.Lipidios);
        }
    }
}
