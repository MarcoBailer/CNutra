using System.ComponentModel.DataAnnotations;

namespace Nutricao.Models
{
    public class CalculoDaRefeicaoPorPosicao
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public double TotalCarboidratos { get; set; }
        public double TotalProteinas { get; set; }
        public double TotalGorduras { get; set; }
        public double TotalCalorias { get; set; }
        public double TotalFibras { get; set; }
        public int Posicao { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
    }
}
