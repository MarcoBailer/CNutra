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
            var result = await _foodInformation.GetFoodNutrition(EFoodCategory.Fruits,fruitName);

            return Ok(result);
        }

        [HttpGet("food/vegetable/{vegetableName}")]
        public async Task<IActionResult> GetVegetable(string vegetableName)
        {
            var result = await _foodInformation.GetFoodNutrition(EFoodCategory.Vegetables, vegetableName);

            return Ok(result);
        }

        [HttpGet("food/beef/{beefName}")]
        public async Task<IActionResult> GetBeef(string beefName)
        {
            var result = await _foodInformation.GetFoodNutrition(EFoodCategory.Beef, beefName);

            return Ok(result);
        }

        [HttpGet("food/dairyeggs/{dairyEggsName}")]
        public async Task<IActionResult> GetDairyEggs(string dairyEggsName)
        {
            var result = await _foodInformation.GetFoodNutrition(EFoodCategory.DairyEggs, dairyEggsName);

            return Ok(result);
        }

        [HttpGet("food/beverages/{beveragesName}")]
        public async Task<IActionResult> GetBeverages(string beveragesName)
        {
            var result = await _foodInformation.GetFoodNutrition(EFoodCategory.Beverages, beveragesName);

            return Ok(result);
        }

        [HttpGet("food/breakfastcereals/{breakFastCerealsName}")]
        public async Task<IActionResult> GetBreakFastCereals(string breakFastCerealsName)
        {
            var result = await _foodInformation.GetFoodNutrition(EFoodCategory.BreakFastCereals, breakFastCerealsName);

            return Ok(result);
        }

        [HttpGet("food/fatsoils/{fatsOilsName}")]
        public async Task<IActionResult> GetFatsOils(string fatsOilsName)
        {
            var result = await _foodInformation.GetFoodNutrition(EFoodCategory.FatsOils, fatsOilsName);

            return Ok(result);
        }

        [HttpGet("food/finfishshellfish/{finfishShellfishName}")]
        public async Task<IActionResult> GetFinfishShellfish(string finfishShellfishName)
        {
            var result = await _foodInformation.GetFoodNutrition(EFoodCategory.FinfishShellfish, finfishShellfishName);

            return Ok(result);
        }

        [HttpGet("food/legumes/{legumesName}")]
        public async Task<IActionResult> GetLegumes(string legumesName)
        {
            var result = await _foodInformation.GetFoodNutrition(EFoodCategory.Legumes, legumesName);

            return Ok(result);
        }

        [HttpGet("food/nutseed/{nutSeedName}")]
        public async Task<IActionResult> GetNutSeed(string nutSeedName)
        {
            var result = await _foodInformation.GetFoodNutrition(EFoodCategory.NutSeed, nutSeedName);

            return Ok(result);
        }

        [HttpGet("food/pork/{porkName}")]
        public async Task<IActionResult> GetPork(string porkName)
        {
            var result = await _foodInformation.GetFoodNutrition(EFoodCategory.Pork, porkName);

            return Ok(result);
        }

        [HttpGet("food/poultry/{poultryName}")]
        public async Task<IActionResult> GetPoultry(string poultryName)
        {
            var result = await _foodInformation.GetFoodNutrition(EFoodCategory.Poultry, poultryName);

            return Ok(result);
        }
    }
}
