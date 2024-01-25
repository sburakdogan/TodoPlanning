using Newtonsoft.Json;
using TodoPlanning.Models.Dtos;
using TodoPlanning.Models.Mapping;
using TodoPlanning.Providers.Abstract;

namespace TodoPlanning.Providers.Concrete
{
    public class FirstTodoProvider : ITodoProvider
    {
        public async Task<CommonTodoItemDto> GetTodoItems()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://run.mocky.io/v3/0f7a9194-a5d8-4050-91a6-ab087c8a196b");

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var providerResponse = JsonConvert.DeserializeObject<FirstProviderResponseDto>(responseData);

                    var result = FirstProviderDtoMapping.MapToCommonTodoItem(providerResponse);
                    return result;
                }

                else
                {
                    throw new Exception($"First provider operation failed. Status Code: {response.StatusCode}");
                }
            }
        }
    }
}
