using VerifyNullablesObjects;

namespace OrderAPI.Communication
{
    public class PaymentCommunication
    {
        private readonly HttpClient _httpClient;

        public PaymentCommunication(IHttpClientFactory _httpClientFactory)
        {
            _httpClient = _httpClientFactory.CreateClient();
            //_httpClient.BaseAddress = new Uri()
        }


        /// <summary>
        /// Sets Environment
        /// </summary>
        /// <returns></returns>
        //private static string SetUriByEnvironment()
        //{
        //    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        //    if (environment == "Production")
        //    {
        //        var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.Production.json").Build();
        //        return NullOrEmptyVariable<string>.ThrowIfNull(config.GetValue<string>("CtmApiRest"), "API URL was not found");
        //    }
        //    else if (environment == "Acceptance")
        //    {
        //        var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.Acceptance.json").Build();
        //        return NullOrEmptyVariable<string>.ThrowIfNull(config.GetValue<string?>("CtmApiRest"), "API URL was not found");
        //    }
        //    else
        //    {
        //        var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.Development.json").Build();
        //        return NullOrEmptyVariable<string>.ThrowIfNull(config.GetValue<string?>("CtmApiRest"), "API URL was not found");
        //    }
        //}
    }
}
