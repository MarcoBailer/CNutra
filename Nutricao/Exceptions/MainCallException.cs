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
    }
}
