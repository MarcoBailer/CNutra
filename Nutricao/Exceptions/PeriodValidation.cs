using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Nutricao.Exceptions
{
    public class PeriodValidation
    {
        public static void ValidarDia(int dia)
        {
            if (dia <= 0 || dia > 31)
            {
                throw new InvalidPeriodException("O dia deve ser um número positivo entre 1 e 31.");
            }
        }

        public static void ValidarMes(int mes)
        {
            if (mes <= 0 || mes > 12)
            {
                throw new InvalidPeriodException("O mês deve ser um número positivo entre 1 e 12.");
            }
        }
        public static void ValidarTurno(bool isMatinal, bool isVespertina, bool isNoturna)
        {
            if(isMatinal && isVespertina && isNoturna)
            {
                throw new InvalidPeriodException("A refeição não pode ser matinal, vespertina e noturna ao mesmo tempo.");
            }
            else if(!isMatinal && !isVespertina && !isNoturna)
            {
                throw new InvalidPeriodException("A refeição deve ser matinal, vespertina ou noturna.");
            }
            else if(isMatinal && isVespertina)
            {
                throw new InvalidPeriodException("A refeição não pode ser matinal e vespertina ao mesmo tempo.");
            }
            else if(isMatinal && isNoturna)
            {
                throw new InvalidPeriodException("A refeição não pode ser matinal e noturna ao mesmo tempo.");
            }
            else if(isVespertina && isNoturna)
            {
                throw new InvalidPeriodException("A refeição não pode ser vespertina e noturna ao mesmo tempo.");
            }
        }
    }
}
