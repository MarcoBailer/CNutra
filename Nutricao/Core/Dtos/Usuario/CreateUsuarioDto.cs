using static Nutricao.Core.Enum.EnumUsuario.EUsuarioDeficiencia;
using System.ComponentModel.DataAnnotations;

namespace Nutricao.Core.Dtos.Usuario
{
    public class CreateUsuarioDto
    {
        public int ApplicationUserId { get; set; }
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
