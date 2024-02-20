using OrderAPI.Model;
using System.Net.Http.Headers;
using VerifyNullablesObjects;
using Newtonsoft.Json;

namespace OrderAPI.Communication
{
    public class PaymentCommunication
    {
        private readonly HttpClient _httpClient;

        public PaymentCommunication(IHttpClientFactory _httpClientFactory)
        {
            _httpClient = _httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5228/api/Payment/");
        }

        public async Task<Payment> CreatePayment(int userId, int paymentMethod, int qntInstallments, double total, int orderId)
        {
            try
            {

                var requestBody = JsonConvert.SerializeObject(new
                {
                    usuarioId = userId,
                    formaPagamentoId = paymentMethod,
                    pedidoId = orderId,
                    quantidadeParcelas = qntInstallments,
                    total = total
                });

                var content = new StringContent(requestBody);
                content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                var response = await _httpClient.PostAsync(
                    _httpClient.BaseAddress + $"create/{orderId}", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadFromJsonAsync<Payment>();

                    NullOrEmptyVariable<Payment>.ThrowIfNull(responseContent);
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

        public async Task<Payment> CancelPayment(int orderId)
        {
            try
            {
                var payment = await GetPaymentByOrder(orderId);

                //var requestBody = JsonConvert.SerializeObject(payment);

                //var content = new StringContent(requestBody);
                //content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                var response = await _httpClient.PutAsync(
                    _httpClient.BaseAddress + $"cancel/{payment.Id}", null);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadFromJsonAsync<Payment>();

                    NullOrEmptyVariable<Payment>.ThrowIfNull(responseContent);
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

        public async Task<Payment> GetPaymentByOrder(int orderId)
        {
            try
            {
                // chama a API e pega a resposta
                var response = await _httpClient.GetAsync(
                    _httpClient.BaseAddress + $"order/{orderId}");


                if (response.IsSuccessStatusCode)
                {
                    // transforma resposta em um objeto desejado e retorna o objeto
                    var responseContent = await response.Content.ReadFromJsonAsync<Payment>();
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
