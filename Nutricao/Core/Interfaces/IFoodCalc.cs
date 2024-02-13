using Microsoft.AspNetCore.Mvc;
using Nutricao.Core.Dtos;
using Nutricao.Core.Dtos.Refeicao;
using Nutricao.Models;

namespace Nutricao.Core.Interfaces
{
    public interface IFoodCalc 
    {
        Task<FoodServiceResponseSimplifiedDto> AdicionaRefeicao([FromBody] CreateRefeicaoDto refeicao, EFoodCategory foodCategory, string foodName);
        Task<List<RefeicaoMVN>> GetRefeicaoMatinal(int dia, int mes, int ano);
        Task<List<RefeicaoMVN>> GetRefeicaoVespertina(int dia, int mes, int ano);
        Task<List<RefeicaoMVN>> GetRefeicaoNoturna(int dia, int mes, int ano);
        Task<CalculoDaRefeicao> CalculoTotal(int dia, int mes, int ano);
    }
}
