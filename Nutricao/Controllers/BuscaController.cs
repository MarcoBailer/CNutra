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
        [HttpGet("food/categorias")]
        public async Task<IActionResult> GetFoodsFromCategory(EFoodCategory foodCategory)
        {
            var result = await _foodInformation.GetAllFoodFromACategory(foodCategory);

            return Ok(result);
        }
    }
}
