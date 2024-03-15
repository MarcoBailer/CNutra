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
    }
}
