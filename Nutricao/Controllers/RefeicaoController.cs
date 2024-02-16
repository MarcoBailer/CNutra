using Microsoft.AspNetCore.Mvc;
using Nutricao.Core.Dtos.Refeicao;
using Nutricao.Core.Dtos;
using Nutricao.Core.Interfaces;
using Nutricao.Models;
using AutoMapper;
using Nutricao.Core.Dtos.Context;

namespace Nutricao.Controllers
{
    public class RefeicaoController : Controller
    {
        private readonly IFoodInfomation _foodInformation;
        private readonly IFoodCalc _foodCalc;
        public RefeicaoController(IFoodInfomation foodInformation, IFoodCalc foodCalc)
        {
            _foodInformation = foodInformation;
            _foodCalc = foodCalc;
        }

        [HttpPost("RefeicaoUnicaM/V/N")]
        public async Task<IActionResult> AdicionaRefeicaoMVN([FromBody] CreateRefeicaoDto refeicao, string foodName)
        {
            var result = await _foodCalc.AdicionaRefeicao(refeicao, foodName);
            return Ok(result);
        }
        [HttpPost("RefeicaoEmLoteM/V/N/{nomes}")]
        public async Task<List<FoodServiceResponseDto>> AdicionarRefsEmLote([FromBody] CreateRefeicaoDto refeicao, string nomes)
        {
            var result = await _foodCalc.CadastrarVariasRef(refeicao, nomes);
            return result;
        }
        [HttpPost("CalcularNutrientesTotaisDiaria")]
        public async Task<CalculoDaRefeicao> CalculoTotal(int dia, int mes, int ano)
        {
            var result = await _foodCalc.CalculoTotal(dia, mes, ano);
            return result;
        }
        [HttpGet("refeicaoMatinal/{dia}/{mes}/{ano}")]
        public async Task<List<RefeicaoMVN>> GetRefeicaoMatinal(int dia, int mes, int ano)
        {
            var result = await _foodCalc.GetRefeicaoMatinal(dia, mes, ano);
            return result;
        }
        [HttpGet("refeicaoVespertina/{dia}/{mes}/{ano}")]
        public async Task<List<RefeicaoMVN>> GetRefeicaoVespertina(int dia, int mes, int ano)
        {
            var result = await _foodCalc.GetRefeicaoVespertina(dia, mes, ano);
            return result;
        }
        [HttpGet("refeicaoNoturna/{dia}/{mes}/{ano}")]
        public async Task<List<RefeicaoMVN>> GetRefeicaoNoturna(int dia, int mes, int ano)
        {
            var result = await _foodCalc.GetRefeicaoNoturna(dia, mes, ano);
            return result;
        }

    }
}
