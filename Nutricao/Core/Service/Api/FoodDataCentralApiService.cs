using System.Net.Http;
using Newtonsoft.Json;
using Nutricao.Models;

namespace Nutricao.Core.Service.Api
{
    public class FoodDataCentralApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _dataType;

        public FoodDataCentralApiService(string apiKey,string dataType)
        {
            _httpClient = new HttpClient();
            _apiKey = apiKey;
            _dataType = dataType;
        }

        public async Task<Nutrients> GetFoodData(string foodName)
        {
            try
            {
                var apiUrl = $"https://api.nal.usda.gov/fdc/v1/foods/search?api_key={_apiKey}&query={foodName}&dataType={_dataType}";

                var response = await _httpClient.GetAsync(apiUrl);

                Console.WriteLine($"Request URL: {apiUrl}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<ApiResponse>(content);

                    if (result?.Foods != null && result.Foods.Count > 0)
                    {
                        var firstFood = result.Foods[0];

                        var foodInfo = new Nutrients
                        {
                            FoodName = firstFood.Description,
                            Protein = firstFood.FoodNutrients.FirstOrDefault(n => n.NutrientName == "Protein")?.Value ?? 0,
                            Fat = firstFood.FoodNutrients.FirstOrDefault(n => n.NutrientName == "Total lipid (fat)")?.Value ?? 0,
                            Carbohydrate = firstFood.FoodNutrients.FirstOrDefault(n => n.NutrientName == "Carbohydrate, by difference")?.Value ?? 0,
                            Calories = (int)(firstFood.FoodNutrients.FirstOrDefault(n => n.NutrientName == "Energy")?.Value ?? 0),
                            Fiber = firstFood.FoodNutrients.FirstOrDefault(n => n.NutrientName == "Fiber, total dietary")?.Value ?? 0,
                        };

                        return foodInfo;
                    }
                }
                else
                {
                    Console.WriteLine($"Error: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }

            return null;
        }
    }
}
