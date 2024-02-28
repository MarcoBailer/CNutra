﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Newtonsoft.Json;
using Nutricao.Core.Dtos;
using Nutricao.Core.Dtos.Context;
using Nutricao.Core.Dtos.Refeicao;
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
        public async Task<FoodServiceResponseDto> GetAllFoodFromACategory(EFoodCategory foodCategory)
        {
            try
            {
                var foodList = await _apiService.GetAllFoodsFromACategory(foodCategory);

                if (foodList != null && foodList.Any())
                {
                    var result = foodList.Select(foodData => new FoodDetails
                    {
                        Nome = foodData.Nome,
                        Grupo = foodData.Grupo,
                    });
                    return new FoodServiceResponseDto
                    {
                        IsSuccess = true,
                        StatusCode = 200,
                        Message = "Informações encontradas.",
                        Resume = result,
                    };
                }
                else
                {
                    return new FoodServiceResponseDto
                    {
                        IsSuccess = false,
                        Message = $"Informações sobre a categoria {foodCategory} não encontradas.",
                    };
                }
            }
            catch (Exception ex)
            {
                return new FoodServiceResponseDto
                {
                    IsSuccess = false,
                    Message = $"Erro ao buscar informações sobre a categoria: {ex}.",
                };
            }
        }
        public async Task<FoodServiceResponseDto> FoodDetailSearchByName(string foodName)
        {
            try
            {
                var foodList = await _apiService.GetFoodByName(foodName);

                if (foodList != null && foodList.Any())
                {
                    var result = foodList.Select(foodData => new Nutrients
                    {
                        Nome = foodData.Nome,
                        Grupo = foodData.Grupo,
                        Calorias = foodData.Calorias,
                        Fibra_Alimentar = foodData.Fibra_Alimentar,
                        Proteinas = foodData.Proteinas,
                        Lipidios = foodData.Lipidios,
                        Carboidratos = foodData.Carboidratos,
                        Vitaminas = foodData.Vitaminas,
                        Minerais = foodData.Minerais,
                    });
                    return new FoodServiceResponseDto
                    {
                        IsSuccess = true,
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
                    Message = $"Erro ao buscar informações: {ex}.",
                };
            }
        }
    }
}
