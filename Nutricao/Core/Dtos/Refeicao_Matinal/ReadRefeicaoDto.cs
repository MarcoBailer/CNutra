﻿using Nutricao.Core.OtherObjects;

namespace Nutricao.Core.Dtos.Refeicao
{
    public class ReadRefeicaoDto
    {
        public double Carboidratos { get; set; }
        public double Proteinas { get; set; }
        public double Calorias { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
    }
}
