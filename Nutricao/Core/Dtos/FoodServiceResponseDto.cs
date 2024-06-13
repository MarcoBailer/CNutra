using Microsoft.AspNetCore.Mvc;
using Nutricao.Core.OtherObjects;
using Nutricao.Models;

namespace Nutricao.Core.Dtos
{
    public class FoodServiceResponseDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public Nutrients Food { get; set; }
        public IEnumerable<FoodDetails> Resume { get; set; }

        public static FoodServiceResponseDto Ok(IEnumerable<Nutrients> food)
        {
            return new FoodServiceResponseDto
            {
                IsSuccess = true,
                Message = "Informações encontradas.",
                StatusCode = 200,
                Food = food.FirstOrDefault(),
            };
        }
        public static FoodServiceResponseDto Ok(IEnumerable<FoodDetails> resume)
        {
            return new FoodServiceResponseDto
            {
                IsSuccess = true,
                Message = "Informações encontradas.",
                StatusCode = 200,
                Resume = resume,
            };
        }
        public static FoodServiceResponseDto Ok(string message)
        {
            return new FoodServiceResponseDto
            {
                IsSuccess = true,
                Message = message,
                StatusCode = 200,
            };
        }
        public static FoodServiceResponseDto Created(string message)
        {
            return new FoodServiceResponseDto
            {
                IsSuccess = true,
                Message = message,
                StatusCode = 201,
            };
        }
        public static FoodServiceResponseDto NotFound(string message)
        {
            return new FoodServiceResponseDto
            {
                IsSuccess = false,
                Message = message,
                StatusCode = 404,
            };
        }
        public static FoodServiceResponseDto BadRequest(string message)
        {
            return new FoodServiceResponseDto
            {
                IsSuccess = false,
                Message = message,
                StatusCode = 400,
            };
        }
        public static FoodServiceResponseDto InternalServerError(string message)
        {
            return new FoodServiceResponseDto
            {
                IsSuccess = false,
                Message = message,
                StatusCode = 500,
            };
        }
    }
}
