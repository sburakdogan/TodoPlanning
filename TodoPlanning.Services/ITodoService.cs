using TodoPlanning.Models.Dtos;

namespace TodoPlanning.Services
{
    public interface ITodoService
    {
        Task<CommonTodoItemDto> GetProcessedTodoItems();
    }
}
