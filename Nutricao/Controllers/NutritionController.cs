using Microsoft.AspNetCore.Mvc;
using Nutricao.Core.Interfaces;
using Nutricao.Core.Service.Api;

namespace Nutricao.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NutritionController : Controller
    {

        private readonly IFoodInfomation _foodInformation;

        public NutritionController(IFoodInfomation foodInformation)
        {
            _foodInformation = foodInformation;
        }

        [HttpGet("foods/{foodName}")]
        public async Task<IActionResult> GetFoodNutrition(FoodCategory foodCategory,string foodName)
        {
            var result = await _foodInformation.GetFoodNutrition(foodCategory, foodName);

            return Ok(result);
        }

        [HttpGet("foods/fruit/{fruitName}")]
        public async Task<IActionResult> GetFruit(string fruitName)
        {
            var result = await _foodInformation.GetFoodNutrition(FoodCategory.Fruits, fruitName);

            return Ok(result);
        }
    }
}
