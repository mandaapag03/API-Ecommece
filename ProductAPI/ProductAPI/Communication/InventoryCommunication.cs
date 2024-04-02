using Newtonsoft.Json;
using ProductAPI.Model;
using System.Net.Http.Headers;
using VerifyNullablesObjects;

namespace ProductAPI.Communication
{
    public class InventoryCommunication
    {
        private readonly HttpClient _httpClient;

        public InventoryCommunication(IHttpClientFactory _httpClientFactory)
        {
            _httpClient = _httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://inventory-api:8080/api/Inventory/");
            // _httpClient.BaseAddress = new Uri("http://localhost:5082/api/Inventory/");
        }

        public async Task<Inventory> AddProductToInventory(int productId)
        {
            try
            {
                var requestBody = JsonConvert.SerializeObject(new
                {
                    productId = productId,
                    quantity = 0
                });

                var content = new StringContent(requestBody);
                content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                var response = await _httpClient.PostAsync(
                    _httpClient.BaseAddress + $"add", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadFromJsonAsync<Inventory>();

                    NullOrEmptyVariable<Inventory>.ThrowIfNull(responseContent);
                    return responseContent;
                }
                else
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    throw new Exception(responseContent);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
