using TodoPlanning.Models.Dtos;

namespace TodoPlanning.Models.Mapping
{
    public class SecondProviderDtoMapping
    {
        public static CommonTodoItemDto MapToCommonTodoItem(SecondProviderResponseDto dto)
        {
            var commonDto = new CommonTodoItemDto
            {
                Developer = MapDeveloperDtoList(dto.Developers),
                Tasks = MapTaskDtoList(dto.Tasks),
                ProviderName = "Second"
            };

            return commonDto;
        }

        private static List<DeveloperDto> MapDeveloperDtoList(List<SecondProviderDeveloperDto> SecondProviderDevelopers)
        {
            return SecondProviderDevelopers.Select(developer => new DeveloperDto
            {
                Name = developer.Name,
                HourlyCapacity = developer.Capacity
            }).ToList();
        }

        private static List<TaskDto> MapTaskDtoList(List<SecondProviderTaskDto> SecondProviderTasks)
        {
            return SecondProviderTasks.Select(task => new TaskDto
            {
                Name = task.Name,
                Duration = task.Duration,
                Difficulty = task.Difficulty
            }).ToList();
        }
    }
}
