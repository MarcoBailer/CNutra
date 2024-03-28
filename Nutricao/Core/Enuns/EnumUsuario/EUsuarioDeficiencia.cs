namespace Nutricao.Core.Enum.EnumUsuario
{
    public class EUsuarioDeficiencia
    {
        public enum DeficienciaFisica
        {
            Nenhuma = 1,
            Surdez = 2,
            Paralisia = 3,
            Nanismo = 4,
            Cegueira = 5,
            ParalisiaCerebral = 6,
            DistrofiaMuscular = 8,
        }
        public enum DeficienciaCognitiva
        {
            Nenhuma = 1,
            Autismo = 2,
            SindromeDeDown = 3,
            Outra = 4
        }
        public enum Trauma
        {
            Nenhum = 1,
            RompimentoLigamentarDoJoelho = 2,
            RompimentoLigamentarDoOmbro = 3,
            Fratura = 4,
            LuxacaoDoOmbro = 5,
            LuxacaoDoJoelho = 6,
        }
    }
}
