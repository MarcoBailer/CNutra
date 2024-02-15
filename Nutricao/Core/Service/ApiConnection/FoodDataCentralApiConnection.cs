using System.Net.Http;
using Newtonsoft.Json;
using Nutricao.Core.OtherObjects;

namespace Nutricao.Core.Service.Api
{
    public class FoodDataCentralApiConnection
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public FoodDataCentralApiConnection(string apiKey)
        {
            _httpClient = new HttpClient();
            _apiKey = apiKey;
        }
        public async Task<List<Nutrients>> GetAllFoodsFromACategory(EFoodCategory foodCategory)
        {
            try
            {
                var categoryString = EnumExtensions.GetDescription(foodCategory);

                var apiUrl = $"http://localhost:3000/alimentos/grupo/{categoryString}";

                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<ApiResponse>(content);

                    if (result != null)
                    {
                        return result.Alimentos;
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
        public async Task<List<Nutrients>> GetFoodByName(string foodName)
        {
            try
            {
                var apiUrl = $"http://localhost:3000/alimentos/nome/{foodName}";

                var response = await _httpClient.GetAsync(apiUrl);

                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<List<Nutrients>>(content);

                    if(result != null)
                    {
                        return result;
                    }
                }
                else
                {
                    Console.WriteLine($"Error: {response.ReasonPhrase}");
                }
            }catch(Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
            return null;
        }
    }
}
