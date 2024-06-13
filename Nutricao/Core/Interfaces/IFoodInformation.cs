using Microsoft.AspNetCore.Mvc;
using Nutricao.Core.Dtos;
using Nutricao.Core.Dtos.Refeicao;
using Nutricao.Models;

namespace Nutricao.Core.Interfaces
{
    public interface IFoodInfomation
    {
        Task<FoodServiceResponseDto> GetAllFoodFromACategory(EFoodCategory foodCategory);
        Task<FoodServiceResponseDto> FoodDetailSearchByName(string foodName);
    }
}
