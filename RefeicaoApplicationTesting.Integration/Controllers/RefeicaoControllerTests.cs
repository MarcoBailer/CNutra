using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using Nutricao.Core.Dtos;
using Nutricao.Core.Dtos.Refeicao;
using Nutricao.Core.Dtos.Refeicao_MVN;
using Nutricao.Core.OtherObjects;
using Nutricao.Models;
using RefeicaoApplicationTesting.Integration.Factory;
using System.Net;
using System.Net.Http.Json;
using System.Text;

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

            var mockRead = new ReadRefeicaoDto
            {
                Dia = 1,
                Mes = 1,
                Ano = 2024
            };

            var refeicoesFiltradas = mockRefeicoes
                .Where(r => r.Dia == mockRead.Dia && r.Mes == mockRead.Mes && r.Ano == mockRead.Ano)
                .ToList();

            _factory.FoodCalcMock.Setup(f => f.GetRefeicao(It.IsAny<RefeicaoQuery>()))
                .ReturnsAsync(refeicoesFiltradas);

            var response = await _client.GetAsync($"api/Refeicao/refeicao?Dia={mockRead.Dia}&Mes={mockRead.Mes}&Ano={mockRead.Ano}");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var data = JsonConvert.DeserializeObject<IEnumerable<RefeicaoMVN>>(await response.Content.ReadAsStringAsync());

            Assert.Equal(refeicoesFiltradas.Count, data.Count());
        }
        [Fact]
        public async Task Get_Always_ReturnsAllRefeicoesByPosition()
        {
            var mockRefeicoes = RefeicaoMVNFactory.CreateMockRefeicoes().AsQueryable();

            var mockRead = new ReadRefeicaoDto
            {
                Dia = 1,
                Mes = 1,
                Ano = 2024
            };

            var posicao = 1;

            var refeicoesFiltradas = mockRefeicoes
                .Where(r => r.Dia == mockRead.Dia && r.Mes == mockRead.Mes && r.Ano == mockRead.Ano && r.Posicao == posicao)
                .ToList();


            _factory.FoodCalcMock.Setup(f => f.GetRefeicaoPorPosicao(It.IsAny<RefeicaoQuery>(), It.IsAny<int>()))
                .ReturnsAsync(refeicoesFiltradas.ToList());

            var response = await _client.GetAsync($"api/Refeicao/refeicaoLugar?Dia={mockRead.Dia}&Mes={mockRead.Mes}&Ano={mockRead.Ano}&lugar={posicao}");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var data = JsonConvert.DeserializeObject<IEnumerable<RefeicaoMVN>>(await response.Content.ReadAsStringAsync());

            Assert.Equal(refeicoesFiltradas.Count, data.Count());
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
        [Fact]
        public async Task Get_Always_ReturnAllCalculoDeRefeicao()
        {
            var mockRefeicaoCalculada = RefeicaoMVNFactory.CreateMockRefeicaoCalculada();

            _factory.FoodCalcMock.Setup(f => f.GetCalculoRefeicao(It.IsAny<RefeicaoQuery>()))
                .ReturnsAsync(mockRefeicaoCalculada);

            var response = await _client.GetAsync("api/Refeicao/CalculoRefeicao");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var data = JsonConvert.DeserializeObject<CalculoDaRefeicao>(await response.Content.ReadAsStringAsync());

            _factory.FoodCalcMock.VerifyAll();
        }
        [Fact]
        public async Task Get_Always_ReturnAllCalculoDeRefeicaoPelaPosicao()
        {
            var mockRefeicaoCalculada = RefeicaoMVNFactory.CreateMockRefeicoes().AsQueryable().ToList();

            _factory.FoodCalcMock.Setup(f => f.CalcularTotalRefeicaoPelaPosicao(It.IsAny<RefeicaoQuery>(), It.IsAny<int>()))
                .ReturnsAsync(new FoodServiceResponseDto
                {
                    Message = "Calculo feito com sucesso",
                    IsSuccess = true
                });

            var response = await _client.GetAsync("api/Refeicao/CalcularNutrientesTotaisPelaPosicao");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            _factory.FoodCalcMock.VerifyAll();
        }
        [Fact]
        public async Task Delete_Always_RemoveRefeicao()
        {
            var mockRefeicao = RefeicaoMVNFactory.CreateMockRefeicoes().AsQueryable();

            _factory.FoodCalcMock.Setup(f => f.RemoveRefeicao(It.IsAny<RefeicaoQuery>(), It.IsAny<string>()))
                .ReturnsAsync(new FoodServiceResponseDto
                {
                    Message = "Refeicao removida com sucesso",
                    IsSuccess = true
                });

            var nomeRefeicao = "Ref2";

            var response = await _client.DeleteAsync($"api/Refeicao/RemoverRefeicao?nome={nomeRefeicao}");

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
