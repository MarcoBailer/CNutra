using FoodDataCentral.Models;

namespace Nutricao.Models
{
    public class Nutrients
    {
        public string FoodName { get; set; }
        public int Calories { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
        public double Fiber { get; set; }
        public double Carbohydrate { get; set; }
    }
}
