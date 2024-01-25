using TodoPlanning.Models.Dtos;

namespace TodoPlanning.Models.Mapping
{
    public class ThirdProviderDtoMapping
    {
        public static CommonTodoItemDto MapToCommonTodoItem(ThirdProviderResponseDto dto)
        {
            var commonDto = new CommonTodoItemDto
            {
                Developer = MapDeveloperDtoList(dto.Developers),
                Tasks = MapTaskDtoList(dto.Tasks),
                ProviderName = "Third"
            };

            return commonDto;
        }

        private static List<DeveloperDto> MapDeveloperDtoList(List<ThirdProviderDeveloperDto> ThirdProviderDevelopers)
        {
            return ThirdProviderDevelopers.Select(developer => new DeveloperDto
            {
                Name = developer.Dev_Name,
                HourlyCapacity = developer.Capacity_Per_Hour
            }).ToList();
        }

        private static List<TaskDto> MapTaskDtoList(List<ThirdProviderTaskDto> ThirdProviderTasks)
        {
            return ThirdProviderTasks.Select(task => new TaskDto
            {
                Name = task.Task_Name,
                Duration = task.Task_Duration,
                Difficulty = task.Task_Difficulty
            }).ToList();
        }
    }
}
