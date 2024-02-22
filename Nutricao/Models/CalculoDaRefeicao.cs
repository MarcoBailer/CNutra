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
        public static double CalcularTotalCarboidratos(List<RefeicaoMVN> refeicao)
        {
            return
                RefeicaoMVN.CalcularTotalCarboidratos(refeicao);
        }
        public static double CalcularTotalProteinas(List<RefeicaoMVN> refeicao)
        {
            return
                RefeicaoMVN.CalcularTotalProteinas(refeicao);
        }
        public static double CalcularTotalGorduras(List<RefeicaoMVN> refeicao)
        {
            return
                RefeicaoMVN.CalcularTotalLipidios(refeicao);
        }
        public static double CalcularTotalCalorias(List<RefeicaoMVN> refeicao)
        {
            return
                RefeicaoMVN.CalcularTotalCalorias(refeicao);
        }
    }

}
