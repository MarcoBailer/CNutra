using Microsoft.AspNetCore.Mvc;
using Nutricao.Core.Service.Api;

namespace Nutricao.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NutritionController : Controller
    {
        private readonly FoodDataCentralApiService _apiService;

        public NutritionController(FoodDataCentralApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet("foods/{foodName}")]
        public async Task<IActionResult> GetFoodNutrition(string foodName)
        {
            try
            {
                var foodData = await _apiService.GetFoodData(foodName);

                if (foodData != null)
                {
                    return Ok(new
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
                else if (foodData == null)
                {
                    return NotFound($"Informações sobre o {foodName} não encontradas");
                }
                else
                {
                    // Handle case when foodData.Nutrients is null
                    return StatusCode(500, $"As informações sobre os nutrientes para {foodName} não estão disponíveis");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao processar a solicitação: {ex.Message}");
            }
        }
    }
}
