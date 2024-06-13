using Nutricao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefeicaoApplicationTesting.Integration.Factory
{
    public static class RefeicaoMVNFactory
    {
        public static List<RefeicaoMVN> CreateMockRefeicoes()
        {
            return new List<RefeicaoMVN>
            {
                new RefeicaoMVN
                {
                    Id = 1, Nome="Ref1", Dia=1, Mes=1, Ano=2024,
                    Carboidratos=1.5, Proteinas=1, Calorias=2, Lipidios=3, Fibra=0.5,
                    Posicao=1, IsMatinal=true, IsNoturna=false, IsVespertina=false
                },
                new RefeicaoMVN
                {
                    Id = 2, Nome="Ref2", Dia=2, Mes=2, Ano=2024,
                    Carboidratos=0.5, Proteinas=2, Calorias=1.4, Lipidios=1, Fibra=3.5,
                    Posicao=2, IsMatinal=false, IsNoturna=true, IsVespertina=false
                }
            };
        }
        public static RefeicaoMVN CreateMockRefeicao()
        {
            return new RefeicaoMVN
            {
                Id = 3,
                Nome = "Ref3",
                Dia = 3,
                Mes = 3,
                Ano = 2024,
                Carboidratos = 1.5,
                Proteinas = 1,
                Calorias = 2,
                Lipidios = 3,
                Fibra = 0.5,
                Posicao = 1,
                IsMatinal = true,
                IsNoturna = false,
                IsVespertina = false
            };
        }
        public static CalculoDaRefeicao CreateMockRefeicaoCalculada()
        {
            return new CalculoDaRefeicao
            {
                Dia = 1,
                Mes = 1,
                Ano = 2024,
                TotalCarboidratos = 1.5,
                TotalProteinas = 1,
                TotalCalorias = 2,
                TotalGorduras = 3,
                TotalFibras = 0.5
            };
        }
    }
}
