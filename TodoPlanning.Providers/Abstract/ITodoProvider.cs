using TodoPlanning.Models.Dtos;

namespace TodoPlanning.Providers.Abstract
{
    public interface ITodoProvider
    {
        Task<CommonTodoItemDto> GetTodoItems();
    }
}
