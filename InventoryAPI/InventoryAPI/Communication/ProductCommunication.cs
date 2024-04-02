using Newtonsoft.Json;
using System.Net.Http.Headers;
using VerifyNullablesObjects;
using InventoryAPI.Model;

namespace InventoryAPI.Communication
{
    public class ProductCommunication
    {
        private readonly HttpClient _httpClient;

        public ProductCommunication(IHttpClientFactory _httpClientFactory)
        {
            _httpClient = _httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://product-api:8080/api/Product/");
            // _httpClient.BaseAddress = new Uri("http://localhost:5051/api/Product/");
        }

        public async Task<Product> DisableProduct(int productId)
        {
            try
            {
                var response = await _httpClient.PutAsync(
                    _httpClient.BaseAddress + $"inactivate/{productId}", null);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadFromJsonAsync<Product>();

                    NullOrEmptyVariable<Product>.ThrowIfNull(responseContent);
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
