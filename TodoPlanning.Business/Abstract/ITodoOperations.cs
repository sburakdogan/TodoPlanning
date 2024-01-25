using TodoPlanning.Models.Dtos;

namespace TodoPlanning.Business.Abstract
{
    public interface ITodoOperations
    {
        Task AddDevelopers(List<DeveloperDto> developers);
        Task AddTasks(List<TaskDto> tasks);
        Task<List<TaskDto>> GetAllTasks();
        Task<List<DeveloperDto>> GetAllDevelopers();
        Task<List<DeveloperDto>> GetTaskPlan();
    }
}
