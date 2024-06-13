using Nutricao.Domain.Configuration.Models.Auth;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Nutricao.Core.Enum.EnumUsuario.EUsuarioDeficiencia;

namespace Nutricao.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [NotMapped]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public int ApplicationUserId { get; set; }
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
