using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        Task<List<RefeicaoMVN>> GetRefeicao([FromQuery] RefeicaoQuery refeicaoQr);
        Task<List<RefeicaoMVN>> GetRefeicaoPorPosicao([FromQuery] RefeicaoQuery refeicaoQr, int lugar);
        Task<List<RefeicaoMVN>> GetRefeicaoPorTurno([FromQuery] RefeicaoQuery refeicaoQr, bool isMatinal, bool isVespertina, bool isNoturna);
        Task<CalculoDaRefeicao> GetCalculoRefeicao([FromQuery] RefeicaoQuery refeicaoQr);
        Task<CalculoDaRefeicaoPorTurno> GetCalculoRefeicaoPorTurno([FromQuery] RefeicaoQuery refeicaoQr, bool mat, bool vesp, bool not);
        Task<CalculoDaRefeicaoPorPosicao> GetCalculoDaRefeicaoPorPosicao([FromQuery] RefeicaoQuery refeicaoQr, int lugar);
        Task<FoodServiceResponseDto> RemoveRefeicao([FromQuery] RefeicaoQuery refeicao,string nome);
        Task<FoodServiceResponseDto> UpdateRefeicao([FromQuery] RefeicaoQuery refeicao, string nome, string nomeUpdt);
        Task<FoodServiceResponseDto> UpdateRefeicaoDate([FromQuery] RefeicaoQuery refeicao, [FromBody] UpdateRefeicaoDto updt);
    }
}
