namespace TodoPlanning.Models.Dtos
{
    public class CommonTodoItemDto
    {
        public List<DeveloperDto> Developer { get; set; }
        public List<TaskDto> Tasks { get; set; }
        public string ProviderName { get; set; }
    }

    public class DeveloperDto
    {
        public string Name { get; set; }
        public int HourlyCapacity { get; set; }
        public List<TaskDto> AssignedTasks { get; set; } = new List<TaskDto>();
        public int TotalCapacity { get; set; } = 45;
        public string ProviderName { get; set; }
    }

    public class TaskDto
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Difficulty { get; set; }
        public bool IsAssigned { get; set; }
        public string ProviderName { get; set; }
    }
}
