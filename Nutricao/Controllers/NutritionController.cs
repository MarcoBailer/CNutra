﻿using Microsoft.AspNetCore.Mvc;
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
            var result = await _foodInformation.GetFruit(fruitName);

            return Ok(result);
        }

        [HttpGet("foods/vegetable/{vegetableName}")]
        public async Task<IActionResult> GetVegetable(string vegetableName)
        {
            var result = await _foodInformation.GetVegetable(vegetableName);

            return Ok(result);
        }

        [HttpGet("foods/beef/{beefName}")]
        public async Task<IActionResult> GetBeef(string beefName)
        {
            var result = await _foodInformation.GetBeef(beefName);

            return Ok(result);
        }

        [HttpGet("foods/dairyeggs/{dairyEggsName}")]
        public async Task<IActionResult> GetDairyEggs(string dairyEggsName)
        {
            var result = await _foodInformation.GetDairyAndEggs(dairyEggsName);

            return Ok(result);
        }

        [HttpGet("foods/beverages/{beveragesName}")]
        public async Task<IActionResult> GetBeverages(string beveragesName)
        {
            var result = await _foodInformation.GetBeverages(beveragesName);

            return Ok(result);
        }

        [HttpGet("foods/breakfastcereals/{breakFastCerealsName}")]
        public async Task<IActionResult> GetBreakFastCereals(string breakFastCerealsName)
        {
            var result = await _foodInformation.GetBreakFastCereals(breakFastCerealsName);

            return Ok(result);
        }

        [HttpGet("foods/fatsoils/{fatsOilsName}")]
        public async Task<IActionResult> GetFatsOils(string fatsOilsName)
        {
            var result = await _foodInformation.GetFatsOils(fatsOilsName);

            return Ok(result);
        }

        [HttpGet("foods/finfishshellfish/{finfishShellfishName}")]
        public async Task<IActionResult> GetFinfishShellfish(string finfishShellfishName)
        {
            var result = await _foodInformation.GetFinfishShellfish(finfishShellfishName);

            return Ok(result);
        }

        [HttpGet("foods/legumes/{legumesName}")]
        public async Task<IActionResult> GetLegumes(string legumesName)
        {
            var result = await _foodInformation.GetLegumes(legumesName);

            return Ok(result);
        }

        [HttpGet("foods/nutseed/{nutSeedName}")]
        public async Task<IActionResult> GetNutSeed(string nutSeedName)
        {
            var result = await _foodInformation.GetNutSeed(nutSeedName);

            return Ok(result);
        }

        [HttpGet("foods/pork/{porkName}")]
        public async Task<IActionResult> GetPork(string porkName)
        {
            var result = await _foodInformation.GetPork(porkName);

            return Ok(result);
        }

        [HttpGet("foods/poultry/{poultryName}")]
        public async Task<IActionResult> GetPoultry(string poultryName)
        {
            var result = await _foodInformation.GetPoultry(poultryName);

            return Ok(result);
        }
    }
}
