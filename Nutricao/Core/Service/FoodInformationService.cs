using Microsoft.AspNetCore.Mvc;
using Nutricao.Core.Interfaces;
using Nutricao.Core.Service.Api;

namespace Nutricao.Core.Service
{
    public class FoodInformationService : IFoodInfomation
    {
        private readonly FoodDataCentralApiConnection _apiService;

        public FoodInformationService(FoodDataCentralApiConnection apiService)
        {
            _apiService = apiService;
        }
        public async Task<IActionResult> GetFoodNutrition(EFoodCategory foodCategory, string foodName)
        {
            try
            {
                var foodList = await _apiService.GetFoodByCategoryAndName(foodCategory, foodName);

                if (foodList != null && foodList.Any())
                {
                    var result = foodList.Select(foodData => new
                    {
                        FoodName = foodData.Nome,
                        Nutrients = new
                        {
                            Nome = foodData.Nome,
                            Valor = foodData.Grupo,
                            Carboidratos = foodData.Carboidratos,
                            Proteinas = foodData.Proteinas,
                            Lipidios = foodData.Lipidios,
                            Calorias = foodData.Calorias,
                            Vitaminas = foodData.Vitaminas,
                            Minerais = foodData.Minerais
                        }
                    });
                    return new OkObjectResult(result);
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
