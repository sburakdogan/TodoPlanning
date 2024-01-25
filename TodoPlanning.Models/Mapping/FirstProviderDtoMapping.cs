using TodoPlanning.Models.Dtos;

namespace TodoPlanning.Models.Mapping
{
    public class FirstProviderDtoMapping
    {
        public static CommonTodoItemDto MapToCommonTodoItem(FirstProviderResponseDto dto)
        {
            var commonDto = new CommonTodoItemDto
            {
                Developer = MapDeveloperDtoList(dto.Developers),
                Tasks = MapTaskDtoList(dto.Tasks),
                ProviderName = "First"
            };

            return commonDto;
        }

        private static List<DeveloperDto> MapDeveloperDtoList(List<FirstProviderDeveloperDto> firstProviderDevelopers)
        {
            return firstProviderDevelopers.Select(developer => new DeveloperDto
            {
                Name = developer.Name,
                HourlyCapacity = developer.Hourly_Capacity
            }).ToList();
        }

        private static List<TaskDto> MapTaskDtoList(List<FirstProviderTaskDto> firstProviderTasks)
        {
            return firstProviderTasks.Select(task => new TaskDto
            {
                Name = task.Name,
                Duration = task.Duration,
                Difficulty = task.Difficulty
            }).ToList();
        }
    }
}
