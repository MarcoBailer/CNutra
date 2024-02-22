using Microsoft.AspNetCore.Mvc;
using Nutricao.Core.Dtos;
using Nutricao.Core.Dtos.Refeicao;
using Nutricao.Models;

namespace Nutricao.Core.Interfaces
{
    public interface IFoodCalc 
    {
        Task<FoodServiceResponseSimplifiedDto> AdicionaRefeicao([FromBody] CreateRefeicaoDto refeicao, string foodName);
        Task<List<FoodServiceResponseDto>> CadastrarVariasRef([FromBody] CreateRefeicaoDto refeicao, string nomes);
        Task<CalculoDaRefeicao> CalculoTotal([FromBody] ReadRefeicaoDto refeicao);
        Task<List<RefeicaoMVN>> GetRefeicao([FromQuery] ReadRefeicaoDto refeicao);
        Task<FoodServiceResponseDto> RemoveRefeicao([FromQuery] ReadRefeicaoDto refeicao,string nome);
        Task<FoodServiceResponseDto> UpdateRefeicao([FromQuery] ReadRefeicaoDto refeicao, [FromBody] UpdateRefeicaoDto updt);
        Task<FoodServiceResponseDto> UpdateRefeicaoDate([FromQuery] ReadRefeicaoDto refeicao, [FromBody] UpdateRefeicaoDto updt);
    }
}
