using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Nutricao.Core.Dtos;
using Nutricao.Core.Interfaces;
using Nutricao.Core.OtherObjects;
using Nutricao.Core.Service.Api;
using Nutricao.Models;

namespace Nutricao.Core.Service
{
    public class FoodInformationService : IFoodInfomation
    {
        private readonly FoodDataCentralApiConnection _apiService;

        public FoodInformationService(FoodDataCentralApiConnection apiService)
        {
            _apiService = apiService;
        }
        public async Task<FoodServiceResponseSimplifiedDto> FoodDetailNameAndCategory(EFoodCategory foodCategory, string foodName)
        {
            try
            {

                var foodList = await _apiService.GetFoodByCategoryAndName(foodCategory, foodName);

                if (foodList != null && foodList.Any())
                {
                    var result = foodList.Select(foodData => new FoodDetails
                    {
                        Nome = foodData.Nome,
                        Grupo = foodData.Grupo,
                    });
                    return new FoodServiceResponseSimplifiedDto
                    {
                        Food = result,
                        IsSuccess = true,
                        Message = $"Informações sobre o {foodName} encontradas.",
                        StatusCode = 200,
                    };
                }
                else
                {
                    return new FoodServiceResponseSimplifiedDto
                    {
                        IsSuccess = false,
                        Message = $"Informações sobre o {foodName} não encontradas.",
                        StatusCode = 404,
                    };
                }
            }catch(Exception ex)
            {
                return new FoodServiceResponseSimplifiedDto
                {
                    IsSuccess = false,
                    Message = $"Erro ao buscar informações sobre o {foodName}.",
                    StatusCode = 500,
                };
            }
        }
        public async Task<FoodServiceResponseDto> AllFoodDetails(EFoodCategory foodCategory, string foodName)
        {
            try
            {
                var foodList = await _apiService.GetFoodByCategoryAndName(foodCategory, foodName);

                if (foodList != null && foodList.Any())
                {
                    var result = foodList.Select(foodData => new Nutrients
                    {
                        Nome = foodData.Nome,
                        Grupo = foodData.Grupo,
                        Calorias = foodData.Calorias,
                        Proteinas = foodData.Proteinas,
                        Lipidios = foodData.Lipidios,
                        Carboidratos = foodData.Carboidratos,
                        Vitaminas = foodData.Vitaminas,
                        Minerais = foodData.Minerais,
                    });
                    return new FoodServiceResponseDto
                    {                      
                        Food = result.FirstOrDefault(),
                    };
                }
                else
                {
                    return new FoodServiceResponseDto
                    {
                        IsSuccess = false,
                        Message = $"Informações sobre o {foodName} não encontradas.",
                    };
                }
            }catch(Exception ex)
            {
                return new FoodServiceResponseDto
                {
                    IsSuccess = false,
                    Message = $"Erro ao buscar informações sobre o {foodName}.",
                };
            }
        }
        //Responsável por procurar o nome e a categoria
        public async Task<FoodServiceResponseSimplifiedDto> GetFoodName(EFoodCategory foodCategory, string foodName)
        {
            var result = await FoodDetailNameAndCategory(foodCategory, foodName);
            
            return result;
        }
    }
}
