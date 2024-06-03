using OrderAPI.Model;
using System.Net.Http.Headers;
using VerifyNullablesObjects;
using Newtonsoft.Json;
using OrderAPI.Utils;

namespace OrderAPI.Communication
{
    public class EmailCommunication
    {
        private readonly HttpClient _httpClient;

        public EmailCommunication(IHttpClientFactory _httpClientFactory)
        {
            _httpClient = _httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://email-api:8080/api/Email/");
        }

        public async Task<bool> OrderCreatedEmail(User user)
        {
            try
            {
                var templateEmail = ReadFile.ReadTemplateOrderCreated(user);
                var requestBody = JsonConvert.SerializeObject(new
                {
                    toEmails = user.Email,
                    subject = "Seu pedido da Oh My Dog foi criado",
                    body = templateEmail
                });

                var content = new StringContent(requestBody);
                content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                var response = await _httpClient.PostAsync(
                    _httpClient.BaseAddress + $"SendEmail", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
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

        // public async Task<Payment> CancelPayment(int orderId)
        // {
        //     try
        //     {
        //         var payment = await GetPaymentByOrder(orderId);

        //         //var requestBody = JsonConvert.SerializeObject(payment);

        //         //var content = new StringContent(requestBody);
        //         //content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

        //         var response = await _httpClient.PutAsync(
        //             _httpClient.BaseAddress + $"cancel/{payment.Id}", null);

        //         if (response.IsSuccessStatusCode)
        //         {
        //             var responseContent = await response.Content.ReadFromJsonAsync<Payment>();

        //             NullOrEmptyVariable<Payment>.ThrowIfNull(responseContent);
        //             return responseContent;
        //         }
        //         else
        //         {
        //             var responseContent = await response.Content.ReadAsStringAsync();
        //             throw new Exception(responseContent);
        //         }
        //     }
        //     catch (Exception)
        //     {

        //         throw;
        //     }

        // }
    }
}
