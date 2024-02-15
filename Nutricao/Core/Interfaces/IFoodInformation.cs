using Microsoft.AspNetCore.Mvc;
using Nutricao.Core.Dtos;
using Nutricao.Models;

namespace Nutricao.Core.Interfaces
{
    public interface IFoodInfomation
    {
        Task<FoodServiceResponseSimplifiedDto> GetAllFoodFromACategory(EFoodCategory foodCategory);
        Task<FoodServiceResponseDto> FoodDetailSearchByName(string foodName);
        Task<List<FoodServiceResponseDto>> BuscarInformaçõesPorNomes(string nomes);
    }
}
