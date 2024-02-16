using Microsoft.AspNetCore.Mvc;
using Nutricao.Core.Dtos;
using Nutricao.Core.Dtos.Refeicao;
using Nutricao.Models;

namespace Nutricao.Core.Interfaces
{
    public interface IFoodCalc 
    {
        Task<FoodServiceResponseSimplifiedDto> AdicionaRefeicao([FromBody] CreateRefeicaoDto refeicao, string foodName);
        Task<List<RefeicaoMVN>> GetRefeicao([FromQuery] ReadRefeicaoDto refeicao);
        Task<CalculoDaRefeicao> CalculoTotal([FromBody] ReadRefeicaoDto refeicao);
        Task<List<FoodServiceResponseDto>> CadastrarVariasRef([FromBody] CreateRefeicaoDto refeicao, string nomes);

    }
}
