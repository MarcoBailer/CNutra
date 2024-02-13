using System.ComponentModel.DataAnnotations;

namespace Nutricao.Models
{
    public class RefeicaoVespertina
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

        public static double CalcularTotalCarboidratosVespertina(List<RefeicaoVespertina> refeicaoVespertina)
        {
            return refeicaoVespertina.Sum(r => r.Carboidratos);
        }
        public static double CalcularTotalProteinasVespertina(List<RefeicaoVespertina> refeicaoVespertina)
        {
            return refeicaoVespertina.Sum(r => r.Proteinas);
        }
        public static double CalcularTotalCaloriasVespertina(List<RefeicaoVespertina> refeicaoVespertina)
        {
            return refeicaoVespertina.Sum(r => r.Calorias);
        }
        public static double CalcularTotalLipidiosVespertina(List<RefeicaoVespertina> refeicaoVespertina)
        {
            return refeicaoVespertina.Sum(r => r.Lipidios);
        }
    }
}
