using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nutricao.Core.Dtos.Context;
using Nutricao.Core.Dtos.Refeicao;
using Nutricao.Core.Interfaces;
using Nutricao.Core.OtherObjects;
using Nutricao.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Nutricao.Core.Dtos;

namespace Nutricao.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BuscaController : Controller
    {

        private readonly IFoodInfomation _foodInformation;

        public BuscaController(IFoodInfomation foodInformation)
        {
            _foodInformation = foodInformation;
        }

        [HttpGet("foods/{foodName}")]
        public async Task<IActionResult> GetFoodNutrition(EFoodCategory foodCategory,string foodName)
        {
            var result = await _foodInformation.FoodDetailNameAndCategory(foodCategory, foodName);

            return Ok(result);
        }

        [HttpGet("food/frutas/{fruta}")]
        public async Task<IActionResult> GetFruit(string fruta)
        {
            var result = await _foodInformation.FoodDetailNameAndCategory(EFoodCategory.Frutas, fruta);

            return Ok(result);
        }

        [HttpGet("food/vegetais/{Vegetal}")]
        public async Task<IActionResult> GetVegetable(string Vegetal)
        {
            var result = await _foodInformation.FoodDetailNameAndCategory(EFoodCategory.Verduras, Vegetal);

            return Ok(result);
        }

        [HttpGet("food/carnes/{carne}")]
        public async Task<IActionResult> GetBeef(string carne)
        {
            var result = await _foodInformation.FoodDetailNameAndCategory(EFoodCategory.CarneEDerivados, carne);

            return Ok(result);
        }

        [HttpGet("food/OvosDerivados/{Ovo}")]
        public async Task<IActionResult> GetDairyEggs(string ovo)
        {
            var result = await _foodInformation.FoodDetailNameAndCategory(EFoodCategory.OvosEDerivados, ovo);

            return Ok(result);
        }

        [HttpGet("food/bebidas/{Bebida}")]
        public async Task<IActionResult> GetBeverages(string Bebida)
        {
            var result = await _foodInformation.FoodDetailNameAndCategory(EFoodCategory.Bebidas, Bebida);

            return Ok(result);
        }

        [HttpGet("food/Cereais/{Cereal}")]
        public async Task<IActionResult> GetBreakFastCereals(string Cereal)
        {
            var result = await _foodInformation.FoodDetailNameAndCategory(EFoodCategory.Cereais, Cereal);

            return Ok(result);
        }

        [HttpGet("food/OleosGorduras/{oleoGordura}")]
        public async Task<IActionResult> GetFatsOils(string oleoGordura)
        {
            var result = await _foodInformation.FoodDetailNameAndCategory(EFoodCategory.OleosEGorduras, oleoGordura);

            return Ok(result);
        }

        [HttpGet("food/Pescados/{Pescado}")]
        public async Task<IActionResult> GetFinfishShellfish(string Pescado)
        {
            var result = await _foodInformation.FoodDetailNameAndCategory(EFoodCategory.Pescados, Pescado);

            return Ok(result);
        }

        [HttpGet("food/legumes/{legume}")]
        public async Task<IActionResult> GetLegumes(string legume)
        {
            var result = await _foodInformation.FoodDetailNameAndCategory(EFoodCategory.Leguminosas, legume);

            return Ok(result);
        }
        [HttpGet("food/LeiteDerivados/{Leite}")]
        public async Task<IActionResult> GetMilk(string Leite)
        {
            var result = await _foodInformation.FoodDetailNameAndCategory(EFoodCategory.LeiteEDerivados, Leite);

            return Ok(result);
        }
        [HttpGet("food/Açucarados/{Açucarado}")]
        public async Task<IActionResult> GetSugar(string Açucarado)
        {
            var result = await _foodInformation.FoodDetailNameAndCategory(EFoodCategory.Açucarados, Açucarado);

            return Ok(result);
        }
        [HttpGet("food/Micelanias/{Micelania}")]
        public async Task<IActionResult> GetMicelanias(string Micelania)
        {
            var result = await _foodInformation.FoodDetailNameAndCategory(EFoodCategory.Micelania, Micelania);

            return Ok(result);
        }
        [HttpGet("food/OutroIndustrializados/{OutroIndustrializado}")]
        public async Task<IActionResult> GetOther(string OutroIndustrializado)
        {
            var result = await _foodInformation.FoodDetailNameAndCategory(EFoodCategory.OutrosIndustrializados, OutroIndustrializado);

            return Ok(result);
        }
        [HttpGet("food/preparados/{AlimentoPreparado}")]
        public async Task<IActionResult> GetReady(string AlimentoPreparado)
        {
            var result = await _foodInformation.FoodDetailNameAndCategory(EFoodCategory.AlimentosPreparados, AlimentoPreparado);

            return Ok(result);
        }
    }
}
