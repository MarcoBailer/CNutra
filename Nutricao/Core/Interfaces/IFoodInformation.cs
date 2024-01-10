using Microsoft.AspNetCore.Mvc;
using Nutricao.Models;

namespace Nutricao.Core.Interfaces
{
    public interface IFoodInfomation
    {
        Task<IActionResult> GetFoodNutrition(FoodCategory foodCategory, string foodName);
    }
}
