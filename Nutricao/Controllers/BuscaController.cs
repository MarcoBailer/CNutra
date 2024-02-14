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

        [HttpGet("food/frutas")]
        public async Task<IActionResult> GetFruit()
        {
            var result = await _foodInformation.GetAllFoodFromACategory(EFoodCategory.Frutas);

            return Ok(result);
        }

        [HttpGet("food/vegetais")]
        public async Task<IActionResult> GetVegetable()
        {
            var result = await _foodInformation.GetAllFoodFromACategory(EFoodCategory.Verduras);

            return Ok(result);
        }

        [HttpGet("food/carnes")]
        public async Task<IActionResult> GetBeef()
        {
            var result = await _foodInformation.GetAllFoodFromACategory(EFoodCategory.CarneEDerivados);

            return Ok(result);
        }

        [HttpGet("food/OvosDerivados")]
        public async Task<IActionResult> GetDairyEggs(string ovo)
        {
            var result = await _foodInformation.GetAllFoodFromACategory(EFoodCategory.OvosEDerivados);

            return Ok(result);
        }

        [HttpGet("food/bebidas")]
        public async Task<IActionResult> GetBeverages()
        {
            var result = await _foodInformation.GetAllFoodFromACategory(EFoodCategory.Bebidas);

            return Ok(result);
        }

        [HttpGet("food/Cereais")]
        public async Task<IActionResult> GetBreakFastCereals()
        {
            var result = await _foodInformation.GetAllFoodFromACategory(EFoodCategory.Cereais);

            return Ok(result);
        }

        [HttpGet("food/OleosGorduras")]
        public async Task<IActionResult> GetFatsOils()
        {
            var result = await _foodInformation.GetAllFoodFromACategory(EFoodCategory.OleosEGorduras);

            return Ok(result);
        }

        [HttpGet("food/Pescados")]
        public async Task<IActionResult> GetFinfishShellfish()
        {
            var result = await _foodInformation.GetAllFoodFromACategory(EFoodCategory.Pescados);

            return Ok(result);
        }

        [HttpGet("food/legumes")]
        public async Task<IActionResult> GetLegumes()
        {
            var result = await _foodInformation.GetAllFoodFromACategory(EFoodCategory.Leguminosas);

            return Ok(result);
        }
        [HttpGet("food/LeiteDerivados")]
        public async Task<IActionResult> GetMilk()
        {
            var result = await _foodInformation.GetAllFoodFromACategory(EFoodCategory.LeiteEDerivados);

            return Ok(result);
        }
        [HttpGet("food/Açucarados")]
        public async Task<IActionResult> GetSugar()
        {
            var result = await _foodInformation.GetAllFoodFromACategory(EFoodCategory.Açucarados);

            return Ok(result);
        }
        [HttpGet("food/Micelanias")]
        public async Task<IActionResult> GetMicelanias()
        {
            var result = await _foodInformation.GetAllFoodFromACategory(EFoodCategory.Micelania);

            return Ok(result);
        }
        [HttpGet("food/OutroIndustrializados")]
        public async Task<IActionResult> GetOther()
        {
            var result = await _foodInformation.GetAllFoodFromACategory(EFoodCategory.OutrosIndustrializados);

            return Ok(result);
        }
        [HttpGet("food/preparados")]
        public async Task<IActionResult> GetReady()
        {
            var result = await _foodInformation.GetAllFoodFromACategory(EFoodCategory.AlimentosPreparados);

            return Ok(result);
        }
    }
}
