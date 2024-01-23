using Microsoft.AspNetCore.Mvc;
using Nutricao.Core.Dtos;
using Nutricao.Core.Dtos.Refeicao;
using Nutricao.Core.Dtos.Refeicao_Noturna;
using Nutricao.Core.Dtos.Refeicao_Vespertina;
using Nutricao.Models;

namespace Nutricao.Core.Interfaces
{
    public interface IFoodCalc 
    {
        Task<FoodServiceResponseSimplifiedDto> AdicionaRefeicaoMatinal([FromBody] CreateRefeicaoDto refeicao, EFoodCategory foodCategory, string foodName);
        Task<FoodServiceResponseSimplifiedDto> AdicionaRefeicaoVespertina([FromBody] CreateRefeicaoVespertinaDto refeicao, EFoodCategory foodCategory, string foodName);
        Task<FoodServiceResponseSimplifiedDto> AdicionaRefeicaoNoturna([FromBody] CreateRefeicaoNoturnaDto refeicao, EFoodCategory foodCategory, string foodName);
        Task<List<RefeicaoMatinal>> GetRefeicaoMatinal(int dia, int mes, int ano);
        Task<List<RefeicaoVespertina>> GetRefeicaoVespertina(int dia, int mes, int ano);
        Task<List<RefeicaoNoturna>> GetRefeicaoNoturna(int dia, int mes, int ano);
        Task<CalculoDaRefeicao> CalculoTotal(int dia, int mes, int ano);
    }
}
