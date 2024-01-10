using System.Net.Http;
using FoodDataCentral.Models;
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
        public async Task<Nutrients> GetFoodByCategoryAndName(FoodCategory foodCategory, string foodName)
        {
            try
            {
                var categoryString = EnumExtensions.GetDescription(foodCategory);

                var apiUrl = $"https://api.nal.usda.gov/fdc/v1/foods/search?api_key={_apiKey}&query={foodName}&dataType={_dataType}&FoodCategory={categoryString}";

                var response = await _httpClient.GetAsync(apiUrl);

                Console.WriteLine($"Request URL: {apiUrl}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<ApiResponse>(content);

                    if (result?.Foods != null && result.Foods.Count > 0)
                    {
                        string bestMatch = null;
                        int bestMatchDistance = int.MaxValue;

                        foreach (var food in result.Foods)
                        {
                            int distance = CalculateLevenshteinDistance(food.Description.ToLower(), foodName.ToLower());

                            if (distance < bestMatchDistance)
                            {
                                bestMatch = food.Description;
                                bestMatchDistance = distance;
                            }
                        }

                        // Agora, bestMatch contém o nome que mais se assemelha ao input
                        // pode continuar o processo para obter os nutrientes desse alimento

                        var bestMatchFood = result.Foods.FirstOrDefault(f => f.Description == bestMatch);

                        if (bestMatchFood != null)
                        {
                            var foodInfo = new Nutrients
                            {
                                FoodName = bestMatchFood.Description,
                                Protein = bestMatchFood.FoodNutrients.FirstOrDefault(n => n.NutrientName == "Protein")?.Value ?? 0,
                                Fat = bestMatchFood.FoodNutrients.FirstOrDefault(n => n.NutrientName == "Total lipid (fat)")?.Value ?? 0,
                                Carbohydrate = bestMatchFood.FoodNutrients.FirstOrDefault(n => n.NutrientName == "Carbohydrate, by difference")?.Value ?? 0,
                                Calories = (int)(bestMatchFood.FoodNutrients.FirstOrDefault(n => n.NutrientName == "Energy")?.Value ?? 0),
                                Fiber = bestMatchFood.FoodNutrients.FirstOrDefault(n => n.NutrientName == "Fiber, total dietary")?.Value ?? 0,
                            };
                            return foodInfo;
                        }
                    }
                    return null;
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

        private int CalculateLevenshteinDistance(string a, string b)
        {
            // Implementação básica do algoritmo de distância de Levenshtein
            // Pode ser substituído por uma biblioteca mais avançada se necessário

            int[,] dp = new int[a.Length + 1, b.Length + 1];

            for (int i = 0; i <= a.Length; i++)
            {
                for (int j = 0; j <= b.Length; j++)
                {
                    if (i == 0)
                        dp[i, j] = j;
                    else if (j == 0)
                        dp[i, j] = i;
                    else
                        dp[i, j] = Math.Min(Math.Min(dp[i - 1, j - 1] + (a[i - 1] == b[j - 1] ? 0 : 1),
                                                     dp[i, j - 1] + 1),
                                            dp[i - 1, j] + 1);
                }
            }

            return dp[a.Length, b.Length];
        }
    }
}
