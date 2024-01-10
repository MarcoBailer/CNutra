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
    }
}
