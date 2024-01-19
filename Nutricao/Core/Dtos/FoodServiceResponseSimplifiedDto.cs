using Nutricao.Core.OtherObjects;
using Nutricao.Models;

namespace Nutricao.Core.Dtos
{
    public class FoodServiceResponseSimplifiedDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public IEnumerable<FoodDetails> Food { get; set; }
    }
}
