using Moq;
using Newtonsoft.Json;
using Nutricao.Core.Dtos;
using Nutricao.Core.Dtos.Refeicao;
using Nutricao.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace WebApplicationIntegrationTest.ControllerTests
{
    public class RefeicaoControllerTests : IDisposable
    {
        private CustomWebApplicationFactory _factory;
        private HttpClient _client;

        public RefeicaoControllerTests()
        {
            _factory = new CustomWebApplicationFactory();
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task Get_Always_ReturnsAllRefeicoes()
        {
            var mockRefeicoes = new RefeicaoMVN[]
            {
                new()
                {
                    Id = 1, Nome="Ref1", Dia=1, Mes=1, Ano=2024,
                    Carboidratos=1.5, Proteinas=1, Calorias=2, Lipidios=3, Fibra=0.5,
                    Posicao=1, IsMatinal=true, IsNoturna=false, IsVespertina=false
                },
                new()
                {
                    Id = 2, Nome="Ref2", Dia=2, Mes=2, Ano=2024,
                    Carboidratos=0.5, Proteinas=2, Calorias=1.4, Lipidios=1, Fibra=3.5,
                    Posicao=2, IsMatinal=false, IsNoturna=true, IsVespertina=false
                }
            }.AsQueryable();

            _factory.FoodCalcMock.Setup(f => f.GetRefeicao(It.IsAny<ReadRefeicaoDto>()))
                .ReturnsAsync(mockRefeicoes.ToList());

            var response = await _client.GetAsync("api/Refeicao/refeicao");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var data = JsonConvert.DeserializeObject<IEnumerable<RefeicaoMVN>>(await response.Content.ReadAsStringAsync());

            Assert.Collection((data as List<RefeicaoMVN>)!,
                    item =>
                    {
                        Assert.Equal(1, item.Id);
                        Assert.Equal("Ref1", item.Nome);
                    },
                    item =>
                    {
                        Assert.Equal(2, item.Id);
                        Assert.Equal("Ref2", item.Nome);
                    }
                );
        }
        [Fact]
        public async Task Get_Always_ReturnsAllRefeicoesByPosition()
        {
            var mockRefeicoes = new RefeicaoMVN[]
            {
                new()
                {
                    Id = 1, Nome="Ref1", Dia=1, Mes=1, Ano=2024,
                    Carboidratos=1.5, Proteinas=1, Calorias=2, Lipidios=3, Fibra=0.5,
                    Posicao=1, IsMatinal=true, IsNoturna=false, IsVespertina=false
                },
                new()
                {
                    Id = 2, Nome="Ref2", Dia=2, Mes=2, Ano=2024,
                    Carboidratos=0.5, Proteinas=2, Calorias=1.4, Lipidios=1, Fibra=3.5,
                    Posicao=2, IsMatinal=false, IsNoturna=true, IsVespertina=false
                }
            }.AsQueryable();

            _factory.FoodCalcMock.Setup(f => f.GetRefeicaoByPlace(It.IsAny<ReadRefeicaoDto>(), It.IsAny<int>()))
                .ReturnsAsync(mockRefeicoes.ToList());

            var response = await _client.GetAsync("api/Refeicao/refeicaoLugar");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var data = JsonConvert.DeserializeObject<IEnumerable<RefeicaoMVN>>(await response.Content.ReadAsStringAsync());

            Assert.Collection((data as List<RefeicaoMVN>)!,
                item =>
                {
                    Assert.Equal(1, item.Id);
                    Assert.Equal("Ref1", item.Nome);
                },
                item =>
                {
                    Assert.Equal(2, item.Id);
                    Assert.Equal("Ref2", item.Nome);
                }
             );
        }
        [Fact]
        public async Task Post_CalculoDeUmaRefeicao()
        {
            var mockRefeicao = new List<RefeicaoMVN>()
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
            };
            var mockRefeicoes = new CalculoDaRefeicao
            {
                Id = 1,
                TotalCarboidratos = RefeicaoMVN.CalcularTotalCarboidratos(mockRefeicao),
                TotalProteinas = RefeicaoMVN.CalcularTotalProteinas(mockRefeicao),
                TotalGorduras = RefeicaoMVN.CalcularTotalLipidios(mockRefeicao),
                TotalCalorias = RefeicaoMVN.CalcularTotalCalorias(mockRefeicao),
                TotalFibras = RefeicaoMVN.CalcularTotalFibras(mockRefeicao),
                Dia = 1,
                Mes = 1,
                Ano = 2024
            };

            _factory.FoodCalcMock.Setup(f => f.CalculoTotal(It.IsAny<ReadRefeicaoDto>()))
                .ReturnsAsync(new FoodServiceResponseDto
                {
                    Message = "Calculo feito com sucesso",
                    IsSuccess = true
                });

            var response = await _client.PostAsync("api/Refeicao/CalcularNutrientesTotaisDiaria", JsonContent.Create(mockRefeicoes));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            _factory.FoodCalcMock.VerifyAll();
        }

        public void Dispose()
        {
            _client.Dispose();
            _factory.Dispose();
        }
    }
}
