using TodoPlanning.Models.Dtos;
using TodoPlanning.Providers.Abstract;
using TodoPlanning.Providers.Factory;

namespace TodoPlanning.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoProvider _todoProvider;

        public TodoService(ITodoProviderFactory todoProviderFactory, string providerType)
        {
            _todoProvider = todoProviderFactory.CreateTodoProvider(providerType);
        }

        public async Task<CommonTodoItemDto> GetProcessedTodoItems()
        {
            var todoItems = await _todoProvider.GetTodoItems();

            return todoItems;
        }
    }
}
