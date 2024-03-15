using Moq;
using Newtonsoft.Json;
using Nutricao.Core.Dtos;
using Nutricao.Core.Dtos.Refeicao_MVN;
using Nutricao.Models;
using RefeicaoApplicationTesting.Integration.Factory;
using System.Net;
using System.Net.Http.Json;

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
            var mockRefeicoes = RefeicaoMVNFactory.CreateMockRefeicoes().AsQueryable();

            var mockRefeicoesParaRetorno = new List<RefeicaoMVN>();

            var entradaDia = 1;
            var entradaMes = 1;
            var entradaAno = 2024;

            foreach (var refeicao in mockRefeicoes)
            {
                if(refeicao.Dia == entradaDia && refeicao.Mes == entradaMes && refeicao.Ano == entradaAno)
                {
                    mockRefeicoesParaRetorno.Add(refeicao);
                }
            }
            
            _factory.FoodCalcMock.Setup(f => f.GetRefeicao(It.IsAny<RefeicaoQuery>()))
                .ReturnsAsync(mockRefeicoesParaRetorno.ToList());

            var response = await _client.GetAsync($"api/Refeicao/refeicao?Dia={entradaDia}&Mes={entradaMes}&Ano={entradaAno}");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var data = JsonConvert.DeserializeObject<IEnumerable<ReadRefeicaoDto>>(await response.Content.ReadAsStringAsync());

            Assert.Equal(1, data.Count());
        }
        [Fact]
        public async Task Get_Always_ReturnsAllRefeicoesByPosition()
        {
            var mockRefeicoes = RefeicaoMVNFactory.CreateMockRefeicoes().AsQueryable();

            var mockRefeicoesParaRetorno = new List<RefeicaoMVN>();

            var entradaDia = 1;
            var entradaMes = 1;
            var entradaAno = 2024;
            var entradaLugar = 1;

            foreach (var refeicao in mockRefeicoes)
            {
                if(refeicao.Dia == entradaDia && refeicao.Mes == entradaMes && refeicao.Ano == entradaAno && refeicao.Posicao == entradaLugar)
                {
                    mockRefeicoesParaRetorno.Add(refeicao);
                }
            }

            _factory.FoodCalcMock.Setup(f => f.GetRefeicaoByPlace(It.IsAny<RefeicaoQuery>(), It.IsAny<int>()))
                .ReturnsAsync(mockRefeicoesParaRetorno.ToList());

            var response = await _client.GetAsync($"api/Refeicao/refeicaoLugar?Dia={entradaDia}&Mes={entradaMes}&Ano={entradaAno}&lugar{entradaLugar}");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var data = JsonConvert.DeserializeObject<IEnumerable<ReadRefeicaoDto>>(await response.Content.ReadAsStringAsync());

            Assert.Equal(1, data.Count());
        }
        [Fact]
        public async Task Get_Always_ReturnCalculoDaRefeicao()
        {
            var mockCalculo = RefeicaoMVNFactory.CreateMockCalculo().AsQueryable();

            var mockCalculoParaRetorno = new List<CalculoDaRefeicao>();

            var entradaDia = 1;
            var entradaMes = 1;
            var entradaAno = 2024;

            foreach (var calculo in mockCalculo)
            {
                if(calculo.Dia == entradaDia && calculo.Mes == entradaMes && calculo.Ano == entradaAno)
                {
                    mockCalculoParaRetorno.Add(calculo);
                }
            }

            _factory.FoodCalcMock.Setup(f => f.GetCalculoRefeicao(It.IsAny<RefeicaoQuery>()))
                .ReturnsAsync(mockCalculoParaRetorno.FirstOrDefault());

            var response = await _client.GetAsync("api/Refeicao/CalculoRefeicao");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var data = JsonConvert.DeserializeObject<ReadCalculoDto>(await response.Content.ReadAsStringAsync());

            Assert.Equal(1.5, data.TotalCarboidratos);
        }
        [Fact]
        public async Task Post_CalculoDeUmaRefeicao()
        {
            var mockRefeicao = RefeicaoMVNFactory.CreateMockRefeicoes().AsQueryable().ToList();
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

            _factory.FoodCalcMock.Setup(f => f.CalculoTotal(It.IsAny<RefeicaoQuery>()))
                .ReturnsAsync(new FoodServiceResponseDto
                {
                    Message = "Calculo feito com sucesso",
                    IsSuccess = true
                });

            var response = await _client.PostAsync("api/Refeicao/CalcularNutrientesTotaisDiaria", JsonContent.Create(mockRefeicoes));

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            _factory.FoodCalcMock.VerifyAll();
        }
        [Fact]
        public async Task Post_CadastrarRefeicoes()
        {
            var newMockRefeicoes = RefeicaoMVNFactory.CreateMockRefeicao();

            _factory.FoodCalcMock.Setup(f => f.CadastrarVariasRef(It.IsAny<RefeicaoMVN>()))
                .ReturnsAsync(new FoodServiceResponseDto
                {
                    Message = "Refeicao cadastrada com sucesso",
                    IsSuccess = true
                });

            var response = await _client.PostAsync("api/Refeicao/AdicionarRefeicao", JsonContent.Create(newMockRefeicoes));

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
