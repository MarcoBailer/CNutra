using System.ComponentModel.DataAnnotations;

namespace Nutricao.Models
{
    public class RefeicaoMVN
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Carboidratos { get; set; }
        public double Proteinas { get; set; }
        public double Calorias { get; set; }
        public double Lipidios { get; set; }
        public double Fibra { get; set; }
        public int Peso { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public bool IsMatinal { get; set; }
        public bool IsVespertina { get; set; }
        public bool IsNoturna { get; set; }
        public int Posicao { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

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
        public static double CalcularTotalFibras(List<RefeicaoMVN> refeicaoMVN)
        {
            return refeicaoMVN.Sum(r => r.Fibra);
        }
        public static double CalcularQuantidadePeloPeso(double peso, double quantidade)
        {
            return (peso * quantidade) / 100;
        }   
    }
}
