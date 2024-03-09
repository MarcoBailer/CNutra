using Microsoft.AspNetCore.Mvc;
using Nutricao.Core.Dtos.Refeicao;
using Nutricao.Core.Dtos;
using Nutricao.Core.Interfaces;
using Nutricao.Models;
using AutoMapper;
using Nutricao.Core.Dtos.Context;

namespace Nutricao.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RefeicaoController : Controller
    {
        private readonly IFoodCalc _foodCalc;
        public RefeicaoController(IFoodCalc foodCalc)
        {
            _foodCalc = foodCalc;
        }

        [HttpPost("AdicionarRefeicao")]
        public async Task<FoodServiceResponseDto> AdicionarRefsEmLote([FromBody] CreateRefeicaoDto refeicao)
        {
            var result = await _foodCalc.CadastrarVariasRef(refeicao);
            return result;
        }
        [HttpPost("CalcularNutrientesTotaisDiaria")]
        public async Task<FoodServiceResponseDto> CalculoTotal([FromQuery] ReadRefeicaoDto refeicao)
        {
            var result = await _foodCalc.CalculoTotal(refeicao);
            return result;
        }
        [HttpGet("CalcularNutrientesTotaisPelaPosicao")]
        public async Task<FoodServiceResponseDto> CalcularTotalRefeicaoPelaPosicao([FromQuery] ReadRefeicaoDto refeicao, int lugar)
        {
            var result = await _foodCalc.CalcularTotalRefeicaoPelaPosicao(refeicao, lugar);
            return result;
        }
        [HttpGet("CalculoRefeicao")]
        public async Task<CalculoDaRefeicao> GetCalculoRefeicao([FromQuery] ReadRefeicaoDto refeicao)
        {
            var result = await _foodCalc.GetCalculoRefeicao(refeicao);
            return result;
        }
        [HttpGet("refeicao")]
        public async Task<List<RefeicaoMVN>> GetRefeicao([FromQuery] ReadRefeicaoDto refeicao)
        {
            var result = await _foodCalc.GetRefeicao(refeicao);
            return result;
        }
        [HttpGet("refeicaoLugar")]
        public async Task<List<RefeicaoMVN>> GetRefeicaoByPlace([FromQuery] ReadRefeicaoDto refeicao, int lugar)
        {
            var result = await _foodCalc.GetRefeicaoByPlace(refeicao, lugar);
            return result;
        }
        [HttpDelete("RemoverRefeicao")]
        public async Task<FoodServiceResponseDto> DeleteRefeicao([FromQuery] ReadRefeicaoDto refeicao, string nome)
        {
            var result = await _foodCalc.RemoveRefeicao(refeicao,nome);
            return result;
        }
        [HttpPut("UpdateRefeicao")]
        public async Task<FoodServiceResponseDto> UpdateRefeicao([FromQuery] ReadRefeicaoDto refeicao, [FromBody] UpdateRefeicaoDto updt)
        {
            var result = await _foodCalc.UpdateRefeicao(refeicao, updt);
            return result;
        }
        [HttpPut("refeicaoData")]
        public async Task<FoodServiceResponseDto> UpdateRefeicaoDate([FromQuery] ReadRefeicaoDto refeicao, [FromBody] UpdateRefeicaoDto updt)
        {
            var result = await _foodCalc.UpdateRefeicaoDate(refeicao, updt);
            return result;
        }
    }
}
