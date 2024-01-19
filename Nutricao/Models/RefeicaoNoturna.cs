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
    }
}
