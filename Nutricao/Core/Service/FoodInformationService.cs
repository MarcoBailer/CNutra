using Microsoft.AspNetCore.Mvc;
using Nutricao.Core.Interfaces;
using Nutricao.Core.Service.Api;

namespace Nutricao.Core.Service
{
    public class FoodInformationService : IFoodInfomation
    {
        private readonly FoodDataCentralApiService _apiService;

        public FoodInformationService(FoodDataCentralApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> GetFoodNutrition(FoodCategory foodCategory, string foodName)
        {
            try
            {
                var foodData = await _apiService.GetFoodByCategoryAndName(foodCategory, foodName);

                if (foodData != null)
                {
                    return new OkObjectResult(new
                    {
                        FoodName = foodData.FoodName,
                        Nutrients = new
                        {
                            Calories = foodData.Calories,
                            Protein = foodData.Protein,
                            Fat = foodData.Fat,
                            Carbohydrate = foodData.Carbohydrate,
                            Fiber = foodData.Fiber
                        }
                    });
                }
                else
                {
                    return new NotFoundObjectResult($"Informações sobre o {foodName} não encontradas");
                }
            }
            catch (Exception ex)
            {
                return new ObjectResult($"Erro ao processar a solicitação: {ex.Message}")
                {
                    StatusCode = 500
                };
            }
        }
        public async Task<IActionResult> GetFruit(string fruitName)
        {
            return await GetFoodNutrition(FoodCategory.Fruits, fruitName);
        }

        public async Task<IActionResult> GetVegetable(string vegetableName)
        {
            return await GetFoodNutrition(FoodCategory.Vegetables, vegetableName);
        }

        public async Task<IActionResult> GetBeef(string meatName)
        {
            return await GetFoodNutrition(FoodCategory.Beef, meatName);
        }

        public async Task<IActionResult> GetBeverages(string meatName)
        {
            return await GetFoodNutrition(FoodCategory.Beverages, meatName);
        }

        public async Task<IActionResult> GetBreakFastCereals(string dairyName)
        {
            return await GetFoodNutrition(FoodCategory.BreakFastCereals, dairyName);
        }
        public async Task<IActionResult> GetDairyAndEggs(string dairyName)
        {
            return await GetFoodNutrition(FoodCategory.DairyEggs, dairyName);
        }

        public async Task<IActionResult> GetFinfishShellfish(string fishName)
        {
            return await GetFoodNutrition(FoodCategory.FinfishShellfish, fishName);
        }

        public async Task<IActionResult> GetFatsOils(string fatName)
        {
            return await GetFoodNutrition(FoodCategory.FatsOils, fatName);
        }

        public async Task<IActionResult> GetPoultry(string poultryName)
        {
            return await GetFoodNutrition(FoodCategory.Poultry, poultryName);
        }

        public async Task<IActionResult> GetPork(string porkName)
        {
            return await GetFoodNutrition(FoodCategory.Pork, porkName);
        }

        public async Task<IActionResult> GetLegumes(string sausageName)
        {
            return await GetFoodNutrition(FoodCategory.Legumes, sausageName);
        }

        public async Task<IActionResult> GetNutSeed(string sausageName)
        {
            return await GetFoodNutrition(FoodCategory.NutSeed, sausageName);
        }
    }
}
