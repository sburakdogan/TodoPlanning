using TodoPlanning.Business.Abstract;
using TodoPlanning.Data.Entities;
using TodoPlanning.Data.Repositories.Abstract;
using TodoPlanning.Models.Dtos;
using TodoPlanning.Providers.Singleton;

namespace TodoPlanning.Business.Concrete
{
    public class TodoOperations : ITodoOperations
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IDeveloperRepository _developerRepository;

        public TodoOperations(ITaskRepository taskRepository, IDeveloperRepository developerRepository)
        {
            _taskRepository = taskRepository;
            _developerRepository = developerRepository;
        }

        public async Task AddDevelopers(List<DeveloperDto> developers)
        {
            var isExisting = await _developerRepository.Any(x => x.ProviderName == ProviderSingleton.Instance.ProviderName);

            if (!isExisting)
            {
                var developersEntity = developers.Select(x => new Developer
                {
                    Name = x.Name,
                    HourlyCapacity = x.HourlyCapacity,
                    ProviderName = ProviderSingleton.Instance.ProviderName
                });

                await _developerRepository.AddRange(developersEntity);
            }
        }

        public async Task AddTasks(List<TaskDto> tasks)
        {
            var isExisting = await _taskRepository.Any(x => x.ProviderName == ProviderSingleton.Instance.ProviderName);

            if (!isExisting)
            {
                var tasksEntity = tasks.Select(x => new Tasks
                {
                    Name = x.Name,
                    ProviderName = ProviderSingleton.Instance.ProviderName,
                    Duration = x.Duration,
                    Difficulty = x.Difficulty,
                });

                await _taskRepository.AddRange(tasksEntity);
            }
        }

        public async Task<List<DeveloperDto>> GetAllDevelopers()
        {
            var developers = await _developerRepository.GetAll();

            return developers.Select(x => new DeveloperDto
            {
                Name = x.Name,
                HourlyCapacity = x.HourlyCapacity,
                ProviderName = x.ProviderName
            }).ToList();
        }

        public async Task<List<TaskDto>> GetAllTasks()
        {
            var tasks = await _taskRepository.GetAll();

            return tasks.Select(x => new TaskDto
            {
                Name = x.Name,
                Difficulty = x.Difficulty,
                Duration = x.Duration,
                ProviderName = x.ProviderName
            }).ToList();
        }

        public async Task<List<DeveloperDto>> GetTaskPlan()
        {
            var tasks = await GetAllTasks();
            var developers = await GetAllDevelopers();

            var developersAssignedTask = TaskPlanning.AssignTasksToDevelopers(developers, tasks);

            return developersAssignedTask;
        }
    }
}
