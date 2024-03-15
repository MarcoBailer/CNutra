using Microsoft.AspNetCore.Mvc;
using Nutricao.Core.Dtos;
using Nutricao.Core.Dtos.Refeicao;
using Nutricao.Models;

namespace Nutricao.Core.Interfaces
{
    public interface IFoodCalc 
    {
        Task<FoodServiceResponseDto> CadastrarVariasRef([FromBody] CreateRefeicaoDto refeicao);
        Task<FoodServiceResponseDto> CalculoTotal([FromBody] ReadRefeicaoDto refeicao);
        Task<FoodServiceResponseDto> CalcularTotalRefeicaoPelaPosicao([FromQuery] ReadRefeicaoDto refeicao, int lugar);
        Task<List<RefeicaoMVN>> GetRefeicao([FromQuery] ReadRefeicaoDto refeicao);
        Task<List<RefeicaoMVN>> GetRefeicaoByPlace([FromQuery] ReadRefeicaoDto refeicao, int lugar);
        Task<CalculoDaRefeicao> GetCalculoRefeicao([FromQuery] ReadRefeicaoDto refeicao);
        Task<FoodServiceResponseDto> RemoveRefeicao([FromQuery] ReadRefeicaoDto refeicao,string nome);
        Task<FoodServiceResponseDto> UpdateRefeicao([FromQuery] ReadRefeicaoDto refeicao, [FromBody] UpdateRefeicaoDto updt);
        Task<FoodServiceResponseDto> UpdateRefeicaoDate([FromQuery] ReadRefeicaoDto refeicao, [FromBody] UpdateRefeicaoDto updt);
    }
}
