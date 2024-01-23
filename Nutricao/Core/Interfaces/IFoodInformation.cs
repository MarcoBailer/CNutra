using Microsoft.AspNetCore.Mvc;
using Nutricao.Core.Dtos;
using Nutricao.Models;

namespace Nutricao.Core.Interfaces
{
    public interface IFoodInfomation
    {
        Task<FoodServiceResponseSimplifiedDto> FoodDetailNameAndCategory(EFoodCategory foodCategory, string foodName);
        Task<FoodServiceResponseDto> AllFoodDetails(EFoodCategory foodCategory, string foodName);
    }
}
