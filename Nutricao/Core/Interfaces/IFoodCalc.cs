using Microsoft.AspNetCore.Mvc;
using Nutricao.Core.Dtos;
using Nutricao.Core.Dtos.Refeicao_MVN;
using Nutricao.Models;

namespace Nutricao.Core.Interfaces
{
    public interface IFoodCalc 
    {
        Task<FoodServiceResponseDto> CadastrarVariasRef([FromBody] RefeicaoMVN refeicao);
        Task<FoodServiceResponseDto> CalculoTotal([FromBody] RefeicaoQuery refeicao);
        Task<FoodServiceResponseDto> CalcularTotalRefeicaoPelaPosicao([FromQuery] RefeicaoQuery refeicao, int lugar);
        Task<FoodServiceResponseDto> CalcularTotalRefeicaoPeloTurno([FromQuery] RefeicaoQuery refeicao, bool mat, bool vesp, bool not);
        Task<List<RefeicaoMVN>> GetRefeicao([FromQuery] RefeicaoQuery refeicao);
        Task<List<RefeicaoMVN>> GetRefeicaoByPlace([FromQuery] RefeicaoQuery refeicao, int lugar);
        Task<CalculoDaRefeicao> GetCalculoRefeicao([FromQuery] RefeicaoQuery refeicao);
        Task<List<RefeicaoMVN>> GetCalculoRefeicaoTurno([FromQuery] RefeicaoQuery refeicaoQr, bool isMatinal, bool isVespertina, bool isNoturna);
        Task<FoodServiceResponseDto> RemoveRefeicao([FromQuery] RefeicaoQuery refeicao,string nome);
        Task<FoodServiceResponseDto> UpdateRefeicao([FromQuery] RefeicaoQuery refeicao, string nome, string nomeUpdt);
        Task<FoodServiceResponseDto> UpdateRefeicaoDate([FromQuery] RefeicaoQuery refeicao, [FromBody] UpdateRefeicaoDto updt);
    }
}
