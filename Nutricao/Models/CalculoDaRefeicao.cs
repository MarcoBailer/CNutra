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
        public static double CalcularTotalCarboidratos(List<RefeicaoMVN> matinal, List<RefeicaoMVN> vespertina, List<RefeicaoMVN> noturna)
        {
            return
                RefeicaoMVN.CalcularTotalCarboidratos(matinal) + RefeicaoMVN.CalcularTotalCarboidratos(vespertina) + RefeicaoMVN.CalcularTotalCarboidratos(noturna);
        }
        public static double CalcularTotalProteinas(List<RefeicaoMVN> matinal, List<RefeicaoMVN> vespertina, List<RefeicaoMVN> noturna)
        {
            return
                RefeicaoMVN.CalcularTotalProteinas(matinal) + RefeicaoMVN.CalcularTotalProteinas(vespertina) + RefeicaoMVN.CalcularTotalProteinas(noturna);
        }
        public static double CalcularTotalGorduras(List<RefeicaoMVN> matinal, List<RefeicaoMVN> vespertina, List<RefeicaoMVN> noturna)
        {
            return
                RefeicaoMVN.CalcularTotalLipidios(matinal) + RefeicaoMVN.CalcularTotalLipidios(vespertina) + RefeicaoMVN.CalcularTotalLipidios(noturna);
        }
        public static double CalcularTotalCalorias(List<RefeicaoMVN> matinal, List<RefeicaoMVN> vespertina, List<RefeicaoMVN> noturna)
        {
            return
                RefeicaoMVN.CalcularTotalCalorias(matinal) + RefeicaoMVN.CalcularTotalCalorias(vespertina) + RefeicaoMVN.CalcularTotalCalorias(noturna);
        }
    }

}
