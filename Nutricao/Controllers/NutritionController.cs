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
        public async Task<IActionResult> GetFoodNutrition(EFoodCategory foodCategory,string foodName)
        {
            var result = await _foodInformation.GetFoodNutrition(foodCategory, foodName);

            return Ok(result);
        }

        [HttpGet("food/fruit/{fruitName}")]
        public async Task<IActionResult> GetFruit(string fruitName)
        {
            var result = await _foodInformation.GetFoodNutrition(EFoodCategory.Frutas,fruitName);

            return Ok(result);
        }

        [HttpGet("food/vegetable/{vegetableName}")]
        public async Task<IActionResult> GetVegetable(string vegetableName)
        {
            var result = await _foodInformation.GetFoodNutrition(EFoodCategory.Verduras, vegetableName);

            return Ok(result);
        }

        [HttpGet("food/beef/{beefName}")]
        public async Task<IActionResult> GetBeef(string beefName)
        {
            var result = await _foodInformation.GetFoodNutrition(EFoodCategory.CarneEDerivados, beefName);

            return Ok(result);
        }

        [HttpGet("food/dairyeggs/{dairyEggsName}")]
        public async Task<IActionResult> GetDairyEggs(string dairyEggsName)
        {
            var result = await _foodInformation.GetFoodNutrition(EFoodCategory.OvosEDerivados, dairyEggsName);

            return Ok(result);
        }

        [HttpGet("food/beverages/{beveragesName}")]
        public async Task<IActionResult> GetBeverages(string beveragesName)
        {
            var result = await _foodInformation.GetFoodNutrition(EFoodCategory.Bebidas, beveragesName);

            return Ok(result);
        }

        [HttpGet("food/breakfastcereals/{breakFastCerealsName}")]
        public async Task<IActionResult> GetBreakFastCereals(string breakFastCerealsName)
        {
            var result = await _foodInformation.GetFoodNutrition(EFoodCategory.Cereais, breakFastCerealsName);

            return Ok(result);
        }

        [HttpGet("food/fatsoils/{fatsOilsName}")]
        public async Task<IActionResult> GetFatsOils(string fatsOilsName)
        {
            var result = await _foodInformation.GetFoodNutrition(EFoodCategory.OleosEGorduras, fatsOilsName);

            return Ok(result);
        }

        [HttpGet("food/finfishshellfish/{finfishShellfishName}")]
        public async Task<IActionResult> GetFinfishShellfish(string finfishShellfishName)
        {
            var result = await _foodInformation.GetFoodNutrition(EFoodCategory.Pescados, finfishShellfishName);

            return Ok(result);
        }

        [HttpGet("food/legumes/{legumesName}")]
        public async Task<IActionResult> GetLegumes(string legumesName)
        {
            var result = await _foodInformation.GetFoodNutrition(EFoodCategory.Leguminosas, legumesName);

            return Ok(result);
        }
        [HttpDelete("food/Leite/{foodName}")]
        public async Task<IActionResult> GetMilk(string foodName)
        {
            var result = await _foodInformation.GetFoodNutrition(EFoodCategory.LeiteEDerivados, foodName);

            return Ok(result);
        }
        [HttpDelete("food/Açucarados/{foodName}")]
        public async Task<IActionResult> GetSugar(string foodName)
        {
            var result = await _foodInformation.GetFoodNutrition(EFoodCategory.Açucarados, foodName);

            return Ok(result);
        }
        [HttpDelete("food/Micelanias/{foodName}")]
        public async Task<IActionResult> GetMicelanias(string foodName)
        {
            var result = await _foodInformation.GetFoodNutrition(EFoodCategory.Micelania, foodName);

            return Ok(result);
        }
        [HttpDelete("food/OutrosIndustrializados/{foodName}")]
        public async Task<IActionResult> GetOther(string foodName)
        {
            var result = await _foodInformation.GetFoodNutrition(EFoodCategory.OutrosIndustrializados, foodName);

            return Ok(result);
        }
        [HttpDelete("food/preparados/{foodName}")]
        public async Task<IActionResult> GetReady(string foodName)
        {
            var result = await _foodInformation.GetFoodNutrition(EFoodCategory.AlimentosPreparados, foodName);

            return Ok(result);
        }
    }
}
