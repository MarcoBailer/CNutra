using Nutricao.Core.OtherObjects;
using System.ComponentModel.DataAnnotations;

namespace Nutricao.Models
{
    public class RefeicaoMatinal
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Carboidratos { get; set; }
        public double Proteinas { get; set; }
        public double Calorias{ get; set; }
        public double Lipidios { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }

        public static double CalcularTotalCarboidratosMatinal(List<RefeicaoMatinal> refeicaoMatinal)
        {
            return refeicaoMatinal.Sum(r => r.Carboidratos);
        }
        public static double CalcularTotalProteinasMatinal(List<RefeicaoMatinal> refeicaoMatinal)
        {
            return refeicaoMatinal.Sum(r => r.Proteinas);
        }
        public static double CalcularTotalCaloriasMatinal(List<RefeicaoMatinal> refeicaoMatinal)
        {
            return refeicaoMatinal.Sum(r => r.Calorias);
        }
        public static double CalcularTotalLipidiosMatinal(List<RefeicaoMatinal> refeicaoMatinal)
        {
            return refeicaoMatinal.Sum(r => r.Lipidios);
        }
    }
}
