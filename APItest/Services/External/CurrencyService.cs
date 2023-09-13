using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;

namespace APItest.Services.External
{
    public class CurrencyService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;
        private const string BaseUrl = "http://api.currencylayer.com/live"; // Replace with the actual API URL


        public CurrencyService(HttpClient _httpClient, IConfiguration _configuration)
        {
            this.httpClient = _httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            this.configuration = _configuration ?? throw new ArgumentNullException(nameof(configuration));

            this.httpClient.BaseAddress = new Uri(BaseUrl);
            this.httpClient.DefaultRequestHeaders.Accept.Clear();
            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetLiveData()
        {
            try
            {
                string apiKey = configuration["APIkeys:MyCurrencyAPIKey"]; // Retrieve the API key from appsettings.json

                // Add the API key as a query parameter in the request URL
                string apiUrl = $"{BaseUrl}?access_key={apiKey}";

                // Make an HTTP GET request to the external API
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);



                // Check if the response is successful
                if (response.IsSuccessStatusCode)
                {
                    // Read and return the response content as a string
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    // Handle the API error or non-successful response here
                    // You can throw an exception or return an error message
                    throw new Exception($"API request failed with status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during the API request
                // You can log the exception or throw it to be handled by the caller
                throw ex;
            }
        }
    }
}
