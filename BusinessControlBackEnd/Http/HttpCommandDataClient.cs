using BusinessControlBackEnd.Dtos;
using System.Text;
using System.Text.Json;

namespace BusinessControlBackEnd.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public async Task SendStoreCommand(StoreDTO plat)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(plat),
                Encoding.UTF8,
                "aplication/json");

            var response = await _httpClient.PostAsync($"{_configuration["CommandService"]}", httpContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("==> sync POST to CommandService was Ok!");
            }
            else
            {
                Console.WriteLine("==> sync POST to CommandService was not ok!");
            }
        }
    }
}
