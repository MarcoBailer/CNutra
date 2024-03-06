namespace Nutricao.Exceptions
{
    public class MainCallException
    {
        public static void ValidarPeriodo(int dia, int mes, bool isMatinal, bool isVespertina, bool isNoturna)
        {
            PeriodValidation.ValidarDia(dia);
            PeriodValidation.ValidarMes(mes);
            PeriodValidation.ValidarTurno(isMatinal, isVespertina, isNoturna);
        }
        public static void ValidarData(int dia, int mes)
        {
            PeriodValidation.ValidarDia(dia);
            PeriodValidation.ValidarMes(mes);
        }
        public static void ValidarTurno(bool isMatinal, bool isVespertina, bool isNoturna)
        {
            PeriodValidation.ValidarTurno(isMatinal, isVespertina, isNoturna);
        }
    }
}
