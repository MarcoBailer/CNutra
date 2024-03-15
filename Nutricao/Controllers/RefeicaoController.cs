using Microsoft.AspNetCore.Mvc;
using Nutricao.Core.Dtos.Refeicao;
using Nutricao.Core.Dtos;
using Nutricao.Core.Interfaces;
using Nutricao.Models;
using AutoMapper;
using Nutricao.Core.Dtos.Refeicao_MVN;

namespace Nutricao.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RefeicaoController : Controller
    {
        private readonly IFoodCalc _foodCalc;
        private readonly IMapper _mapper;

        public RefeicaoController(IFoodCalc foodCalc, IMapper mapper)
        {
            _foodCalc = foodCalc;
            _mapper = mapper;
        }

        [HttpPost("AdicionarRefeicao")]
        public async Task<FoodServiceResponseDto> AdicionarRefsEmLote([FromBody] CreateRefeicaoDto refeicaoDto)
        {
            RefeicaoMVN refeicaoMVN = _mapper.Map<RefeicaoMVN>(refeicaoDto);

            var result = await _foodCalc.CadastrarVariasRef(refeicaoMVN);

            return result;
        }
        [HttpPost("CalcularNutrientesTotaisDiaria")]
        public async Task<FoodServiceResponseDto> CalculoTotal([FromQuery] RefeicaoQuery refeicao)
        {
            var result = await _foodCalc.CalculoTotal(refeicao);
            return result;
        }
        [HttpGet("CalcularNutrientesTotaisPelaPosicao")]
        public async Task<FoodServiceResponseDto> CalcularTotalRefeicaoPelaPosicao([FromQuery] RefeicaoQuery refeicao, int lugar)
        {
            var result = await _foodCalc.CalcularTotalRefeicaoPelaPosicao(refeicao, lugar);
            return result;
        }
        [HttpGet("CalculoRefeicao")]
        public async Task<ReadCalculoDto> GetCalculoRefeicao([FromQuery] RefeicaoQuery refeicao)
        {
            var result = await _foodCalc.GetCalculoRefeicao(refeicao);

            ReadCalculoDto calculo = _mapper.Map<ReadCalculoDto>(result);

            return calculo;
        }
        [HttpGet("refeicao")]
        public async Task<List<ReadRefeicaoDto>> GetRefeicao([FromQuery] RefeicaoQuery refeicao)
        {
            var result = await _foodCalc.GetRefeicao(refeicao);

            List<ReadRefeicaoDto> refeicaoMVN = _mapper.Map<List<ReadRefeicaoDto>>(result);

            return refeicaoMVN;
        }
        [HttpGet("refeicaoLugar")]
        public async Task<List<ReadRefeicaoDto>> GetRefeicaoByPlace([FromQuery] RefeicaoQuery refeicao, int lugar)
        {
            var result = await _foodCalc.GetRefeicaoByPlace(refeicao, lugar);

            List<ReadRefeicaoDto> refeicaoMVN = _mapper.Map<List<ReadRefeicaoDto>>(result);

            return refeicaoMVN;
        }
        [HttpDelete("refeicao")]
        public async Task<FoodServiceResponseDto> DeleteRefeicao([FromQuery] RefeicaoQuery refeicao, string nome)
        {
            var result = await _foodCalc.RemoveRefeicao(refeicao,nome);
            return result;
        }
        [HttpPut("refeicao")]
        public async Task<FoodServiceResponseDto> UpdateRefeicao([FromQuery] RefeicaoQuery refeicao, string nome, string nomeUpdt)
        {
            var result = await _foodCalc.UpdateRefeicao(refeicao, nome, nomeUpdt);
            return result;
        }
        [HttpPut("refeicaoData")]
        public async Task<FoodServiceResponseDto> UpdateRefeicaoDate([FromQuery] RefeicaoQuery refeicao, [FromBody] UpdateRefeicaoDto updt)
        {
            var result = await _foodCalc.UpdateRefeicaoDate(refeicao, updt);
            return result;
        }
    }
}
