using Newtonsoft.Json;
using TodoPlanning.Models.Dtos;
using TodoPlanning.Models.Mapping;
using TodoPlanning.Providers.Abstract;

namespace TodoPlanning.Providers.Concrete
{
    public class SecondTodoProvider : ITodoProvider
    {
        public async Task<CommonTodoItemDto> GetTodoItems()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://run.mocky.io/v3/dcefd558-2d11-4035-9e94-2d6ce27675e0?mocky-delay=5s");

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var providerResponse = JsonConvert.DeserializeObject<SecondProviderResponseDto>(responseData);

                    var result = SecondProviderDtoMapping.MapToCommonTodoItem(providerResponse);
                    return result;
                }

                else
                {
                    throw new Exception($"Second provider operation failed. Status Code: {response.StatusCode}");
                }
            }
        }
    }
}
