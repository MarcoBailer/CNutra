using Nutricao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefeicaoApplicationTesting.Unit
{
    public class RefeicaoControllerTests
    {
        [Fact]
        public void TestaCalculoDosNutrientesDasRefeicoes()
        {
            var refeicao = new RefeicaoMVN[]
            {
                new()
                {
                    Id = 1, Nome="Ref1", Dia=1, Mes=1, Ano=2024,
                    Carboidratos=1.5, Proteinas=1, Calorias=2, Lipidios=3, Fibra=0.5,
                    Posicao=1, IsMatinal=true, IsNoturna=false, IsVespertina=false
                },
                new()
                {
                    Id = 2, Nome="Ref2", Dia=1, Mes=1, Ano=2024,
                    Carboidratos=0.5, Proteinas=2, Calorias=1.4, Lipidios=1, Fibra=3.5,
                    Posicao=2, IsMatinal=false, IsNoturna=true, IsVespertina=false
                }
            }.AsQueryable();

            var totalCarboidratos = RefeicaoMVN.CalcularTotalCarboidratos(refeicao.ToList());
            var totalProteinas = RefeicaoMVN.CalcularTotalProteinas(refeicao.ToList());
            var totalCalorias = RefeicaoMVN.CalcularTotalCalorias(refeicao.ToList());
            var totalLipidios = RefeicaoMVN.CalcularTotalLipidios(refeicao.ToList());
            var totalFibras = RefeicaoMVN.CalcularTotalFibras(refeicao.ToList());
            
            Assert.Equal(2, totalCarboidratos);
            Assert.Equal(3, totalProteinas);
            Assert.Equal(3.4, totalCalorias);
            Assert.Equal(4, totalLipidios);
            Assert.Equal(4, totalFibras);
            
        }
    }
}
