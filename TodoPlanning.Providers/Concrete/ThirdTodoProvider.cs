using TodoPlanning.Models.Dtos;
using TodoPlanning.Models.Mapping;
using TodoPlanning.Providers.Abstract;
using TodoPlanning.Providers.Helper;

namespace TodoPlanning.Providers.Concrete
{
    public class ThirdTodoProvider : ITodoProvider
    {
        public async Task<CommonTodoItemDto> GetTodoItems()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://run.mocky.io/v3/a7775176-a4c6-4c54-be06-caa440df6985?mocky-delay=15s");

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var providerResponse = XmlParseHelper.Deserialize<ThirdProviderResponseDto>(responseData);

                    var result = ThirdProviderDtoMapping.MapToCommonTodoItem(providerResponse);
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
