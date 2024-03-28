using System.ComponentModel.DataAnnotations;
using static Nutricao.Core.Enum.EnumUsuario.EUsuarioDeficiencia;

namespace Nutricao.Models
{
    public class Usuario
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public ESexo Sexo { get; set; }
        public double Altura { get; set; }
        public double Envergadura { get; set; }
        public double Peso { get; set; }
        public EUsuarioObjetivo Objetivo { get; set; }
        public DeficienciaFisica DeficienciaFisica { get; set; }
        public DeficienciaCognitiva DefienciaCognitiva { get; set; }
        public DeficienciaFisica Trauma { get; set; }
        public ERestricaoAlimentar Restricao { get; set; }
        [Range(0, 10)]
        public int PraticaFisica { get; set; }
    }
}
