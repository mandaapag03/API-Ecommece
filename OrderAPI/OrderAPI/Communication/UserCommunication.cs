using OrderAPI.Model;
using System.Net.Http.Headers;
using VerifyNullablesObjects;
using Newtonsoft.Json;

namespace OrderAPI.Communication
{
    public class UserCommunication
    {
        private readonly HttpClient _httpClient;

        public UserCommunication(IHttpClientFactory _httpClientFactory)
        {
            _httpClient = _httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://user-api:8080/api/User/");
        }

        public async Task<User> GetUserData(int userId)
        {
            try
            {
                // chama a API e pega a resposta
                var response = await _httpClient.GetAsync(
                    _httpClient.BaseAddress + $"findById/{userId}");


                if (response.IsSuccessStatusCode)
                {
                    // transforma resposta em um objeto desejado e retorna o objeto
                    var responseContent = await response.Content.ReadFromJsonAsync<User>();
                    return responseContent;
                }
                else
                {
                    //retorna resposta falha da API
                    var responseContent = await response.Content.ReadAsStringAsync();
                    throw new Exception(responseContent);
                }
            }
            catch (Exception)
            {
                // lança exceção
                throw;
            }
        }
    }
}
