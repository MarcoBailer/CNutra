using Microsoft.AspNetCore.Mvc;
using Nutricao.Core.Dtos;
using Nutricao.Core.Dtos.Refeicao;
using Nutricao.Models;

namespace Nutricao.Core.Interfaces
{
    public interface IFoodInfomation
    {
        Task<FoodServiceResponseSimplifiedDto> GetAllFoodFromACategory(EFoodCategory foodCategory);
        Task<FoodServiceResponseDto> FoodDetailSearchByName(string foodName);
    }
}
