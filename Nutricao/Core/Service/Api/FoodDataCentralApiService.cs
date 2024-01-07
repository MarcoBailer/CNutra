using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Nutricao.Core.Service.Api;
using Nutricao.Models;

namespace Nutricao.Core.Service.Api
{
    public class FoodDataCentralApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public FoodDataCentralApiService(string apiKey)
        {
            _httpClient = new HttpClient();
            _apiKey = apiKey;
        }

        public async Task<Nutrients> GetFoodData(string foodName)
        {
            try
            {
                var apiUrl = $"https://api.nal.usda.gov/fdc/v1/foods/search?api_key={_apiKey}&query={foodName}";

                var response = await _httpClient.GetAsync(apiUrl);

                Console.WriteLine($"Request URL: {apiUrl}");
                Console.WriteLine($"Response Status Code: {response.StatusCode}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Response Content: {content}");

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
