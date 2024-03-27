using System.ComponentModel.DataAnnotations;

namespace Nutricao.Models
{
    public class CalculoDaRefeicaoPorTurno
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public double TotalCarboidratos { get; set; }
        public double TotalProteinas { get; set; }
        public double TotalGorduras { get; set; }
        public double TotalCalorias { get; set; }
        public double TotalFibras { get; set; }
        public bool IsMatinal { get; set; }
        public bool IsVespertina { get; set; }
        public bool IsNoturna { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
    }
}
