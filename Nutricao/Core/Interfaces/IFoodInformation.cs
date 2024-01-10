using Microsoft.AspNetCore.Mvc;
using Nutricao.Models;

namespace Nutricao.Core.Interfaces
{
    public interface IFoodInfomation
    {
        Task<IActionResult> GetFoodNutrition(FoodCategory foodCategory, string foodName);
        Task<IActionResult> GetFruit(string fruitName);
        Task<IActionResult> GetVegetable(string vegetableName);
        Task<IActionResult> GetBeef(string meatName);
        Task<IActionResult> GetDairyAndEggs(string dairyEggsName);
        Task<IActionResult> GetBeverages(string beveragesName);
        Task<IActionResult> GetBreakFastCereals(string breakFastCerealsName);
        Task<IActionResult> GetFatsOils(string fatsOilsName);
        Task<IActionResult> GetFinfishShellfish(string finfishShellfishName);
        Task<IActionResult> GetLegumes(string legumesName);
        Task<IActionResult> GetNutSeed(string nutSeedName);
        Task<IActionResult> GetPork(string porkName);
        Task<IActionResult> GetPoultry(string poultryName);

    }
}
