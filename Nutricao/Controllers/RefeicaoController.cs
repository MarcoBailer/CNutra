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
        private readonly IFoodCalc _foodCalc;
        public RefeicaoController(IFoodCalc foodCalc)
        {
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
        public async Task<CalculoDaRefeicao> CalculoTotal([FromQuery] ReadRefeicaoDto refeicao)
        {
            var result = await _foodCalc.CalculoTotal(refeicao);
            return result;
        }
        [HttpGet("refeicao")]
        public async Task<List<RefeicaoMVN>> GetRefeicaoMatinal([FromQuery] ReadRefeicaoDto refeicao)
        {
            var result = await _foodCalc.GetRefeicao(refeicao);
            return result;
        }
        [HttpDelete("refeicao")]
        public async Task<RefeicaoMVN> DeleteRefeicao([FromQuery] ReadRefeicaoDto refeicao, string nome)
        {
            var result = await _foodCalc.RemoveRefeicao(refeicao,nome);
            return result;
        }
        //[HttpPut("refeicao")]
        //public async Task<RefeicaoMVN> UpdateRefeicao([FromBody] UpdateRefeicaoDto refeicao,string nome)
        //{
        //    var result = await _foodCalc.UpdateRefeicao(refeicao,nome);
        //    return result;
        //}
    }
}
