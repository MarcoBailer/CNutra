namespace Nutricao.Core.Service.Api
{
    public class FoodDetails
    {
        public string Description { get; set; }
        public string FoodCategory { get; set; }
        public List<FoodNutrient> FoodNutrients { get; set; }
    }
}
