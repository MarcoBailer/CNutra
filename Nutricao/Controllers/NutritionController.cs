using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Nutricao.Core.Dtos.Context;
using Nutricao.Core.Dtos.Refeicao;
using Nutricao.Core.Interfaces;
using Nutricao.Core.OtherObjects;
using Nutricao.Models;
using Newtonsoft.Json;

namespace Nutricao.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NutritionController : Controller
    {

        private readonly IFoodInfomation _foodInformation;
        private RefeicaoContext _context;
        private IMapper _mapper;

        public NutritionController(IFoodInfomation foodInformation, RefeicaoContext context, IMapper mapper)
        {
            _foodInformation = foodInformation;
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("refeicaoMatinal")]
        public async Task<IActionResult> AdicionaRefeicaoMatinal([FromBody] CreateRefeicaoDto refeicao, EFoodCategory foodCategory, string foodName)
        {
            try
            {
                var result = await _foodInformation.AllFoodDetails(foodCategory, foodName);

                var refeicaoMatinal = new RefeicaoMatinal
                {
                    Dia = refeicao.Dia,
                    Mes = refeicao.Mes,
                    Ano = refeicao.Ano,
                    Calorias = result.Food.Calorias,
                    Carboidratos = result.Food.Carboidratos,
                    Proteinas = result.Food.Proteinas
                };

                _context.RefeicaoMatinal.Add(refeicaoMatinal);
                await _context.SaveChangesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("refeicaoVespertina")]
        public async Task<IActionResult> AdicionaRefeicaoVespertina([FromBody] CreateRefeicaoDto refeicao, EFoodCategory foodCategory, string foodName)
        {
            try
            {
                var result = await _foodInformation.AllFoodDetails(foodCategory, foodName);

                var refeicaoVespertina = new RefeicaoVespertina
                {
                    Dia = refeicao.Dia,
                    Mes = refeicao.Mes,
                    Ano = refeicao.Ano,
                    Calorias = result.Food.Calorias,
                    Carboidratos = result.Food.Carboidratos,
                    Proteinas = result.Food.Proteinas
                };

                _context.RefeicaoVespertina.Add(refeicaoVespertina);
                await _context.SaveChangesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("refeicaoNoturna")]
        public async Task<IActionResult> AdicionaRefeicaoNoturna([FromBody] CreateRefeicaoDto refeicao, EFoodCategory foodCategory, string foodName)
        {
            try
            {
                var result = await _foodInformation.AllFoodDetails(foodCategory, foodName);

                var refeicaoNoturna = new RefeicaoNoturna
                {
                    Dia = refeicao.Dia,
                    Mes = refeicao.Mes,
                    Ano = refeicao.Ano,
                    Calorias = result.Food.Calorias,
                    Carboidratos = result.Food.Carboidratos,
                    Proteinas = result.Food.Proteinas
                };

                _context.RefeicaoNoturna.Add(refeicaoNoturna);
                await _context.SaveChangesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("foods/{foodName}")]
        public async Task<IActionResult> GetFoodNutrition(EFoodCategory foodCategory,string foodName)
        {
            var result = await _foodInformation.GetFoodName(foodCategory, foodName);

            return Ok(result);
        }

        [HttpGet("food/frutas/{fruta}")]
        public async Task<IActionResult> GetFruit(string fruta)
        {
            var result = await _foodInformation.GetFoodName(EFoodCategory.Frutas, fruta);

            return Ok(result);
        }

        [HttpGet("food/vegetais/{Vegetal}")]
        public async Task<IActionResult> GetVegetable(string Vegetal)
        {
            var result = await _foodInformation.GetFoodName(EFoodCategory.Verduras, Vegetal);

            return Ok(result);
        }

        [HttpGet("food/carnes/{carne}")]
        public async Task<IActionResult> GetBeef(string carne)
        {
            var result = await _foodInformation.GetFoodName(EFoodCategory.CarneEDerivados, carne);

            return Ok(result);
        }

        [HttpGet("food/OvosDerivados/{Ovo}")]
        public async Task<IActionResult> GetDairyEggs(string ovo)
        {
            var result = await _foodInformation.GetFoodName(EFoodCategory.OvosEDerivados, ovo);

            return Ok(result);
        }

        [HttpGet("food/bebidas/{Bebida}")]
        public async Task<IActionResult> GetBeverages(string Bebida)
        {
            var result = await _foodInformation.GetFoodName(EFoodCategory.Bebidas, Bebida);

            return Ok(result);
        }

        [HttpGet("food/Cereais/{Cereal}")]
        public async Task<IActionResult> GetBreakFastCereals(string Cereal)
        {
            var result = await _foodInformation.GetFoodName(EFoodCategory.Cereais, Cereal);

            return Ok(result);
        }

        [HttpGet("food/OleosGorduras/{oleoGordura}")]
        public async Task<IActionResult> GetFatsOils(string oleoGordura)
        {
            var result = await _foodInformation.GetFoodName(EFoodCategory.OleosEGorduras, oleoGordura);

            return Ok(result);
        }

        [HttpGet("food/Pescados/{Pescado}")]
        public async Task<IActionResult> GetFinfishShellfish(string Pescado)
        {
            var result = await _foodInformation.GetFoodName(EFoodCategory.Pescados, Pescado);

            return Ok(result);
        }

        [HttpGet("food/legumes/{legume}")]
        public async Task<IActionResult> GetLegumes(string legume)
        {
            var result = await _foodInformation.GetFoodName(EFoodCategory.Leguminosas, legume);

            return Ok(result);
        }
        [HttpGet("food/LeiteDerivados/{Leite}")]
        public async Task<IActionResult> GetMilk(string Leite)
        {
            var result = await _foodInformation.GetFoodName(EFoodCategory.LeiteEDerivados, Leite);

            return Ok(result);
        }
        [HttpGet("food/Açucarados/{Açucarado}")]
        public async Task<IActionResult> GetSugar(string Açucarado)
        {
            var result = await _foodInformation.GetFoodName(EFoodCategory.Açucarados, Açucarado);

            return Ok(result);
        }
        [HttpGet("food/Micelanias/{Micelania}")]
        public async Task<IActionResult> GetMicelanias(string Micelania)
        {
            var result = await _foodInformation.GetFoodName(EFoodCategory.Micelania, Micelania);

            return Ok(result);
        }
        [HttpGet("food/OutroIndustrializados/{OutroIndustrializado}")]
        public async Task<IActionResult> GetOther(string OutroIndustrializado)
        {
            var result = await _foodInformation.GetFoodName(EFoodCategory.OutrosIndustrializados, OutroIndustrializado);

            return Ok(result);
        }
        [HttpGet("food/preparados/{AlimentoPreparado}")]
        public async Task<IActionResult> GetReady(string AlimentoPreparado)
        {
            var result = await _foodInformation.GetFoodName(EFoodCategory.AlimentosPreparados, AlimentoPreparado);

            return Ok(result);
        }
    }
}
