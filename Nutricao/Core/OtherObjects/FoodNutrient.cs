namespace Nutricao.Core.Service.Api
{
    public class FoodNutrient
    {
        public string NutrientName { get; set; }
        public double Value { get; set; }
        public FoodCategory Category { get; set; }
    }
}
